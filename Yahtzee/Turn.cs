namespace Yahtzee
{
    public class Turn
    {
        public Player Player { get; }
        public int RollNumber { get; set; }
        public readonly Hand TurnHand;
        public readonly Table TurnTable;
        public YahtzeeFrom YahtzeeFrom;

        /// <summary>Creates a new turn.</summary>
        /// <param name="player">The player playing the turn.</param>
        /// <param name="yahtzeeFrom">The form the game is being played on.</param>
        public Turn(Player player, YahtzeeFrom yahtzeeFrom)
        {
            this.Player = player;
            this.RollNumber = 0;
            this.TurnHand = new Hand();
            this.TurnTable = new Table();
            this.YahtzeeFrom = yahtzeeFrom;
        }
    }
}