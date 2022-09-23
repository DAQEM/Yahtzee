namespace Yahtzee
{
    public class Constants
    {
        public const int MaxPlayers = 4;
        public const int BeginRollNumber = 0;
        public const int LastRollNumber = 3;
        public const int MaxDice = 5;
        public const int TableY = 203;
        public const int HandY = 322;
        public const int TableStartX = 144;
        public const int HandStartX = 144;
        public const int SpaceBetweenDice = 40;
        public const int FirstDice = 1;
        public static readonly string[] PlayerBasedLabels = {"labelPlayer", "labelPointsPlayer", "labelOnesPlayer", "labelTwosPlayer", 
            "labelThreesPlayer", "labelFoursPlayer", "labelFivesPlayer", "labelSixesPlayer", "labelSumPlayer", 
            "labelBonusPlayer", "labelThreeOfAKindPlayer", "labelFourOfAKindPlayer", "labelFullHousePlayer", 
            "labelSmallStraightPlayer", "labelLargeStraightPlayer", "labelChancePlayer", "labelYahtzeePlayer"};
    }
}