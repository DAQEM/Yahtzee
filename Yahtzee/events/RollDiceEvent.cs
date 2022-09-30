using System;
using System.Windows.Forms;

namespace Yahtzee.events
{
    public class RollDiceEvent
    {
        /// <summary>Event for when the player rolls the dice.</summary>
        /// <param name="sender">The clicked button.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <param name="yahtzeeFrom">The YahtzeeForm the clicked button is on.</param>
        public static void ButtonRollDiceClick(object sender, EventArgs e, YahtzeeFrom yahtzeeFrom)
        {
            Game game = yahtzeeFrom.Game;
            Turn currentTurn = game.CurrentTurn;
            Table currentTable = currentTurn.TurnTable;
            Hand currentHand = currentTurn.TurnHand;

            //Perform next roll if the player isn't out of rolls.
            if (currentTurn.RollNumber != Constants.LastRollNumber)
            {
                //Add roll
                currentTurn.RollNumber += 1;
                
                //Clear all dice from the table
                if (currentTable.GetDiceCount() > 0)
                {
                    currentTable.Clear();
                }
                
                //Add dice to the table.
                int diceToBeAdded = Constants.MaxDice - currentHand.GetDiceCount();
                
                for (int diceCount = 0; diceCount < diceToBeAdded; diceCount++)
                {
                    currentTable.AddNewlyRolledDie(new Die(yahtzeeFrom, currentTable.GetAvailableDictionaryKey()));
                }

                //Set rolls left on screen.
                Label rollsLeftLabel = (Label) yahtzeeFrom.Controls.Find("labelRollsLeft", true)[0];
                int rollsLeftNumber = currentTurn.RollNumber == 0 ? 3 :
                    currentTurn.RollNumber == 1 ? 2 :
                    currentTurn.RollNumber == 2 ? 1 : 0;
                rollsLeftLabel.Text = rollsLeftNumber + " rolls left";

                PointsCalculator.CalculatePoints(new PointsCalculator(currentTurn));
            }
        }
    }
}