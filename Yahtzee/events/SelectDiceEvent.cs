using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Yahtzee.events
{
    public class SelectDiceEvent
    {
        /// <summary>Event for when the player clicks on a die.</summary>
        /// <param name="sender">The clicked die.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <param name="yahtzeeFrom">The YahtzeeForm the clicked die is on.</param>
        public static void dice_Click(object sender, EventArgs e, YahtzeeFrom yahtzeeFrom)
        {
            //The clicked die is always a label.
            Label clickedDieLabel = (Label) sender;
            Table gameTable = yahtzeeFrom.Game.CurrentTurn.TurnTable;
            Hand gameHand = yahtzeeFrom.Game.CurrentTurn.TurnHand;
            
            //Click on dice on the Table
            //Check if hand is not already full
            if (gameHand.GetDiceCount() < 5)
            {
                //Search through all dice on the table for the clicked die.
                foreach (KeyValuePair<int, Die> keyValuePair in gameTable.DiceDictionary.Where(keyValuePair => keyValuePair.Value.DieLabel.Name.Equals(clickedDieLabel.Name)))
                {
                    //Adding the die to the hand and removing it from the table.
                    gameHand.AddExistingDie(keyValuePair.Value, yahtzeeFrom, Constants.HandY);
                    gameTable.RemoveDie(keyValuePair.Value);
                    return;
                }
            }

            //Click on dice in the Hand
            //Check if table if not already full
            if (gameTable.GetDiceCount() < 5)
            {
                //Search through all dice in the hand for the clicked die.
                foreach (KeyValuePair<int, Die> keyValuePair in gameHand.DiceDictionary.Where(keyValuePair => keyValuePair.Value.DieLabel.Name.Equals(clickedDieLabel.Name)))
                {
                    //Adding the die to the table and removing it from the hand.
                    gameTable.AddExistingDie(keyValuePair.Value, yahtzeeFrom, Constants.TableY);
                    gameHand.RemoveDie(keyValuePair.Value);
                    return;
                }
            }
        }
    }
}