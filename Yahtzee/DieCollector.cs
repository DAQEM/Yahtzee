using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    public class DieCollector
    {
        public readonly Dictionary<int, Die> DiceDictionary = new Dictionary<int, Die>();

        /// <summary>Adds an existing die to the hand.</summary>
        /// <param name="die">The die that needs to be added.</param>
        /// <param name="form">The YahtzeeFrom the game is being played on.</param>
        /// <param name="yOffset">The offset on the Y axis the dice will be placed.</param>
        public void AddExistingDie(Die die, YahtzeeFrom form, int yOffset)
        {
            int position = GetAvailableDictionaryKey();
            DiceDictionary.Add(position, new Die(form, position , die.Pips, yOffset));
        }

        /// <summary>Removes a die from the hand.</summary>
        /// <param name="die">The die that needs to be removed.</param>
        public void RemoveDie(Die die)
        {
            die.DisposeFromScreen();
            foreach (KeyValuePair<int, Die> keyValuePair in DiceDictionary.Where(keyValuePair => keyValuePair.Value.Equals(die)))
            {
                DiceDictionary.Remove(keyValuePair.Key);
                break;
            }
        }

        /// <summary>Gets the amount of dice in the hand.</summary>
        /// <returns>The amount of dice in the hand.</returns>
        public int GetDiceCount()
        {
            return DiceDictionary.Count;
        }
        
        /// <summary>Clears all of the die from the table and disposes them from the screen.</summary>
        public void Clear()
        {
            foreach (KeyValuePair<int, Die> keyValuePair in DiceDictionary)
            {
                keyValuePair.Value.DisposeFromScreen();
            }
            DiceDictionary.Clear();
        }
        
        /// <summary>Gets the available key in the dictionary. Used for the screen positioning of the die.</summary>
        /// <returns>1 to 5</returns>
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