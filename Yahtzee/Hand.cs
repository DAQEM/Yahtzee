using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace Yahtzee
{
    public class Hand
    {
        public readonly Dictionary<int, Die> DiceDictionary = new Dictionary<int, Die>();

        public void AddDie(Die die, YahtzeeFrom form)
        {
            int position = GetAvailableDictionaryKey();
            DiceDictionary.Add(position, new Die(form, position , die.Pips, Constants.HandY));
        }

        public void RemoveDie(Die die)
        {
            die.RemoveFromScreen();
            foreach (KeyValuePair<int, Die> keyValuePair in DiceDictionary.Where(keyValuePair => keyValuePair.Value.Equals(die)))
            {
                DiceDictionary.Remove(keyValuePair.Key);
                break;
            }
        }

        public int GetDiceCount()
        {
            return DiceDictionary.Count;
        }
        
        private int GetAvailableDictionaryKey()
        {
            int availableKey = Constants.MaxDice + 1;
            if (GetDiceCount() == 0) availableKey = Constants.FirstDice;
            else
            {
                for (int i = 1; i < Constants.MaxDice + 1; i++)
                {
                    if (!DiceDictionary.ContainsKey(i))
                    {
                        availableKey = i;
                        break;
                    }
                }
            }
            return availableKey;
        }
    }
}