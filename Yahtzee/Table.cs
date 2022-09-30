using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Yahtzee
{
    public class Table : DieCollector
    {
        /// <summary>Adds a newly rolled die to the table.</summary>
        /// <param name="die">The die that needs to be added.</param>
        public void AddNewlyRolledDie(Die die)
        {
            DiceDictionary.Add(GetAvailableDictionaryKey(), die);
        }
    }
}