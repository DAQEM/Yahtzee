using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Yahtzee
{
    public class Table
    {
        public readonly Dictionary<int, Die> DiceDictionary = new Dictionary<int, Die>();

        public void AddDie(Die die)
        {
            DiceDictionary.Add(GetAvailableDictionaryKey(), die);
        }
        
        public void AddDie(YahtzeeFrom form, Die die)
        {
            int position = GetAvailableDictionaryKey();
            DiceDictionary.Add(position, new Die(form, position , die.Pips));
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

        public void Clear()
        {
            foreach (KeyValuePair<int, Die> keyValuePair in DiceDictionary)
            {
                keyValuePair.Value.RemoveFromScreen();
            }
            DiceDictionary.Clear();
        }

        public int GetAvailableDictionaryKey()
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