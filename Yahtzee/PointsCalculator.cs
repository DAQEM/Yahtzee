using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Yahtzee
{
    public class PointsCalculator
    {
        private readonly Turn _turn;
        private readonly YahtzeeFrom _yahtzeeFrom;
        private readonly List<int> _pipsArray = new List<int>();
        
        
        public PointsCalculator(Turn turn)
        {
            _turn = turn;
            _yahtzeeFrom = _turn.YahtzeeFrom;
            
            ClearAllTempPoints(_yahtzeeFrom);
            
            InitializePipsArray();
            
            int count = 1;
            foreach (string labelName in new [] {"labelOnes", "labelTwos", "labelThrees", "labelFours", "labelFives", "labelSixes"})
            {
                Control label = GetLabel(labelName);
                if (!label.Text.Any())
                {
                    SetTempLabelText(label, CountPips(count) * count);
                }
                count++;
            }
            
            bool pairOfTwo = false;
            bool pairOfThree = false;
            
            for (int i = 1; i <= 6; i++)
            {
                int countPips = CountPips(i);
                
                //Three of a kind
                CalculateXOfAKind(countPips, 3, GetLabel("labelThreeOfAKind"), _pipsArray.Sum());

                //Four of a kind
                CalculateXOfAKind(countPips, 4, GetLabel("labelFourOfAKind"), _pipsArray.Sum());

                //Yahtzee
                CalculateXOfAKind(countPips, 5, GetLabel("labelYahtzee"), 50);

                //Full House
                switch (countPips)
                {
                    case 2:
                        pairOfTwo = true;
                        break;
                    case 3:
                        pairOfThree = true;
                        break;
                }
            }
            
            //Full House
            SetTempLabelText(GetLabel("labelFullHouse"),pairOfTwo && pairOfThree ? 25 : 0);
            
            //Chance
            SetTempLabelText(GetLabel("labelChance"), _pipsArray.Sum());

            int straight = CalculateStraight();
            
            //Small Straight
            SetTempLabelText(GetLabel("labelSmallStraight"),straight >= 4 ? 30 : 0);

            //Large Straight
            SetTempLabelText(GetLabel("labelLargeStraight"),straight >= 5 ? 40 : 0);
        }

        private static void CalculateXOfAKind(int countPips, int pips, Control label, int points)
        {
            if (countPips == pips)
            {
                SetTempLabelText(label, points);
            }
            else if (!label.Text.Any())
            {
                SetTempLabelText(label, 0);
            }
        }

        public static void CalculatePoints(PointsCalculator pointsCalculator)
        {
        }

        private void InitializePipsArray()
        {
            foreach (Die die in _turn.TurnTable.DiceDictionary.Values)
            {
                _pipsArray.Add(die.Pips);
            }
            
            foreach (Die die in _turn.TurnHand.DiceDictionary.Values)
            {
                _pipsArray.Add(die.Pips);
            }
        }

        private int CountPips(int number)
        {
            var selectQuery =
                from pips in _pipsArray
                group pips by pips into groupedPips
                select new {groupedPips.Key, Count = groupedPips.Count()};

            return (from pips in selectQuery where pips.Key == number select pips.Count).FirstOrDefault();
        }

        private static void SetTempLabelText(Control label, int value)
        {
            if (!label.Text.Any() || label.ForeColor == Color.Red)
            {
                label.ForeColor = Color.Red;
                label.Text = value.ToString();
            }
        }

        private Control GetLabel(string labelText)
        {
            return _yahtzeeFrom.Controls.Find(labelText + "Player" + _yahtzeeFrom.Game.GetCurrentPlayerNumber(), true)[0];
        }
        
        public static void ClearAllTempPoints(YahtzeeFrom yahtzeeFrom)
        {
            for (int playerNumber = 1; playerNumber <= yahtzeeFrom.Game.Players.Count; playerNumber++)
            {
                foreach (string labelName in new []
                         {
                             "labelOnes", "labelTwos", "labelThrees", "labelFours", "labelFives", "labelSixes", 
                             "labelYahtzee", "labelChance", "labelLargeStraight", "labelSmallStraight",
                             "labelFullHouse", "labelFourOfAKind", "labelThreeOfAKind"
                         })
                {
                    Control label = yahtzeeFrom.Controls.Find(labelName + "Player" + playerNumber, true)[0];
                    if (label.ForeColor == Color.Red)
                    {
                        label.Text = "";
                    }
                }
            }
        }

        /// <summary>Calculates if the player has a straight. A straight is a series of dice like 1, 2, 3 or 2, 3, 4, 5</summary>
        /// <returns>The length of the straight. 1, 2, 3, 4 would return 4. And 5, 6 would return 2.</returns>
        private int CalculateStraight()
        {
            int largestStraight = 0;
            int straight = 1;
            
            List<int> array = new List<int>(_pipsArray);
            array.Sort();
            array = array.Distinct().ToList();

            for (int i = 0; i < array.Count - 1; i++)
            {
                if (array[i + 1] - array[i] == 1)
                {
                    straight++;
                    if (straight > largestStraight)
                    {
                        largestStraight = straight;
                    }
                }
                else
                {
                    if (straight > largestStraight)
                    {
                        largestStraight = straight;
                    }
                    straight = 1;
                }
            }
            return largestStraight;
        }
    }
}