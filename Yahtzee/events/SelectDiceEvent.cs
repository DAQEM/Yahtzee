using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Yahtzee.events
{
    public class SelectDiceEvent
    {
        public static void dice_Click(object sender, EventArgs e, YahtzeeFrom form)
        {
            Label clickedDieLabel = (Label) sender;
            Table gameTable = form.Game.GameTable;
            Hand gameHand = form.Game.GameHand;
            
            if (gameHand.GetDiceCount() < 5)
            {
                foreach (KeyValuePair<int, Die> keyValuePair in gameTable.DiceDictionary.Where(keyValuePair => keyValuePair.Value.DieLabel.Name.Equals(clickedDieLabel.Name)))
                {
                    gameHand.AddDie(keyValuePair.Value, form);
                    gameTable.RemoveDie(keyValuePair.Value);
                    return;
                }
            }

            if (gameTable.GetDiceCount() < 5)
            {
                foreach (KeyValuePair<int, Die> keyValuePair in gameHand.DiceDictionary.Where(keyValuePair => keyValuePair.Value.DieLabel.Name.Equals(clickedDieLabel.Name)))
                {
                    gameTable.AddDie(form, keyValuePair.Value);
                    gameHand.RemoveDie(keyValuePair.Value);
                    return;
                }
            }
        }
    }
}