using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Yahtzee.events
{
    public class SelectPointsEvent
    {
        
        /// <summary>Event for when the player selects the points for the current turn.</summary>
        /// <param name="sender">The clicked label.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <param name="yahtzeeFrom">The YahtzeeForm the clicked label is on.</param>
        public static void labelPoints_Click(object sender, EventArgs e, YahtzeeFrom yahtzeeFrom)
        {
            //Checking if the sender is a label.
            if (sender is Label clickedLabel)
            {
                //Checking if the points haven't been chosen before.
                if (clickedLabel.ForeColor == Color.Red)
                {
                    clickedLabel.ForeColor = Color.Black;
                    PointsCalculator.ClearAllTempPoints(yahtzeeFrom);

                    CheckForBonus(yahtzeeFrom);
                    CheckIfGameIsDone(yahtzeeFrom);
                    
                    yahtzeeFrom.Game.NextTurn(yahtzeeFrom);
                }
            }
        }

        /// <summary>Checks if the player got all the ones through sixes and prints the sum and bonus on the points board.</summary>
        /// <param name="yahtzeeFrom">The YahtzeeFrom the points board is on.</param>
        private static void CheckForBonus(YahtzeeFrom yahtzeeFrom)
        {
            int sum = 0;
            bool hasOneToSix = true;

            //Check if the bonus hasn't been printed already.
            if (!yahtzeeFrom.Controls.Find("labelBonusPlayer" + yahtzeeFrom.Game.GetCurrentPlayerNumber(), true)[0].Text
                    .Any())
            {
                //Loop through labels for ones to sixes.
                foreach (string pointsLabelName in new[]
                             { "labelOnes", "labelTwos", "labelThrees", "labelFours", "labelFives", "labelSixes" })
                {
                    Control pointsLabel =
                        yahtzeeFrom.Controls.Find(pointsLabelName + "Player" + yahtzeeFrom.Game.GetCurrentPlayerNumber(),
                            true)[0];
                    
                    //Check if the player has points for the label.
                    if (pointsLabel.ForeColor == Color.Black)
                    {
                        //Add those points to the sum.
                        sum += int.Parse(pointsLabel.Text);
                    }
                    else
                    {
                        //Assign hasOneToSix as false because the player doesn't have points for this label.
                        hasOneToSix = false;
                    }
                }

                //Check if the player has points for all of the labels.
                if (hasOneToSix)
                {
                    //Print the sum and bonus.
                    yahtzeeFrom.Controls.Find("labelSumPlayer" + yahtzeeFrom.Game.GetCurrentPlayerNumber(), true)[0]
                        .Text = sum.ToString();
                    yahtzeeFrom.Controls.Find("labelBonusPlayer" + yahtzeeFrom.Game.GetCurrentPlayerNumber(), true)[0]
                        .Text = sum >= 64 ? "35" : "0";
                }
            }
        }

        /// <summary>Checks if the game is done and everyone has assigned all of their points.</summary>
        /// <param name="yahtzeeFrom">The YahtzeeForm the game is being played on.</param>
        private static void CheckIfGameIsDone(YahtzeeFrom yahtzeeFrom)
        {
            bool gameIsDone = true;
            //Loop through all of the label the player has to score points for.
            foreach (string pointsLabelName in new[]
                 {
                     "labelOnes", "labelTwos", "labelThrees", "labelFours", "labelFives", "labelSixes",
                     "labelYahtzee", "labelChance", "labelLargeStraight", "labelSmallStraight",
                     "labelFullHouse", "labelFourOfAKind", "labelThreeOfAKind"
                 })
            {
                //Loop through all of the players.
                for (int i = 1; i <= yahtzeeFrom.Game.Players.Count; i++)
                {
                    //Checking if the player has points for the label.
                    Control control = yahtzeeFrom.Controls.Find(pointsLabelName + "Player" + i, true)[0];
                    if (control.ForeColor == Color.Red || !control.Text.Any())
                    {
                        gameIsDone = false;
                    }
                }
            }
            
            if (gameIsDone)
            {
                //Loop though all of the players.
                for (int i = 1; i <= yahtzeeFrom.Game.Players.Count; i++)
                {
                    int totalSum = 0;
                    
                    //Loop through all of the label the player has to score points for and summing the up.
                    foreach (string labelName in new[]
                             {
                                 "labelSum", "labelBonus", "labelYahtzee", "labelChance", "labelLargeStraight",
                                 "labelSmallStraight", "labelFullHouse", "labelFourOfAKind", "labelThreeOfAKind"
                             })
                    {
                        totalSum += int.Parse(yahtzeeFrom.Controls.Find(labelName + "Player" + i, true)[0].Text);
                    }
                    
                    //Print the total sum for the player
                    yahtzeeFrom.Controls.Find("labelPointsPlayer" + i, true)[0].Text = totalSum.ToString();
                }
                
                //Remove all the labels on the left side of the screen.
                foreach (string labelName in new[]
                         {"buttonRollDice", "labelHand", "labelTable", "labelRollsLeft", "labelPlayerPlaying"})
                {
                    yahtzeeFrom.Controls.Find(labelName, true)[0].Dispose();
                }
                
                //Set player won text
                Player playerWon = new Player("dummy");
                int pointsWon = 0;
                for (int i = 1; i <= yahtzeeFrom.Game.Players.Count; i++)
                {
                    int points = int.Parse(yahtzeeFrom.Controls.Find("labelPointsPlayer" + i, true)[0].Text);
                    if (points > pointsWon)
                    {
                        pointsWon = points;
                        playerWon = yahtzeeFrom.Game.GetPlayer(i);
                    }
                }
                Debug.Print(pointsWon.ToString());
                Label playerWonLabel = new Label();
                playerWonLabel.Text = playerWon.Name + " has won with " + pointsWon + " points!";
                playerWonLabel.Size = new Size(200, 50);
                playerWonLabel.Location = new Point(150, 200);
                yahtzeeFrom.Controls.Add(playerWonLabel);
            }
        }
    }
}