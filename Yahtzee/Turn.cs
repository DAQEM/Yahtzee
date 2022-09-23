namespace Yahtzee
{
    public class Turn
    {
        public Player Player { get; }
        public int RollNumber { get; set; }
        private Hand TurnHand;
        private Table TurnTable;
        
        public Turn(Player player, int roll)
        {
            this.Player = player;
            this.RollNumber = roll;
            this.TurnHand = new Hand();
            this.TurnTable = new Table();
        }
    }
}