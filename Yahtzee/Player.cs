namespace Yahtzee
{
    public class Player
    {
        public string Name { get; }
        
        /// <summary>Creates a new player.</summary>
        /// <param name="playerName">The name of the player.</param>
        public Player(string playerName)
        {
            Name = playerName;
        }
        
    }
}