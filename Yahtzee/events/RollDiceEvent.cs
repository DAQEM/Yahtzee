using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Yahtzee.events
{
    public class RollDiceEvent
    {
        public static void ButtonRollDiceClick(object sender, EventArgs e, YahtzeeFrom form)
        {
            Game game = form.Game;
            Turn currentTurn = game.CurrentTurn;
            //Perform next roll if the player isn't out of rolls.
            if (currentTurn.RollNumber != Constants.LastRollNumber)
            {
                currentTurn.RollNumber += 1;
                
                //Clear current dice if present
                if (game.GameTable.GetDiceCount() > 0)
                {
                    game.GameTable.Clear();
                }
                
                //Add dice to the table.
                for (int diceCount = 0; diceCount < Constants.MaxDice - game.GameHand.GetDiceCount(); diceCount++)
                {
                    game.GameTable.AddDie(new Die(form, game.GameTable.GetAvailableDictionaryKey()));
                }

                //Set rolls left on screen.
                Label rollsLeftLabel = (Label) form.Controls.Find("labelRollsLeft", true)[0];
                int rollsLeftNumber = currentTurn.RollNumber == 0 ? 3 :
                    currentTurn.RollNumber == 1 ? 2 :
                    currentTurn.RollNumber == 2 ? 1 : 0;
                rollsLeftLabel.Text = rollsLeftNumber + " Rolls left";
            }
        }
    }
}