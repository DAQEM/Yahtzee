using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Yahtzee
{
    public class Game
    {
        public YahtzeeFrom YFrom;
        public readonly List<Player> Players = new List<Player>();
        public Turn CurrentTurn;
        
        public Game(List<string> playerNames)
        {
            //Loop though all new players and add to Players List
            foreach (string playerName in playerNames)
            {
                AddPlayer(playerName);
            }
            
            //Set first turn for Player 1
            this.CurrentTurn = new Turn(Players[0], Constants.BeginRollNumber);
        }

        private void AddPlayer(string playerName)
        {
            Players.Add(new Player(playerName));
        }

        public Player GetPlayer(int playerNumber)
        {
            return Players[playerNumber - 1];
        }

        private Player GetNextPlayer()
        {
            int currentPlayerNumber = Players.FindIndex(player => player.Equals(CurrentTurn.Player)) + 1;
            return currentPlayerNumber == Players.Count ? GetPlayer(1) : GetPlayer(currentPlayerNumber + 1);
        }
        
        public void NextTurn()
        {
            Player nextPlayer = GetNextPlayer();
            SetIsPlayingText(nextPlayer);
            CurrentTurn = new Turn(nextPlayer, Constants.BeginRollNumber);
        }

        public void SetIsPlayingText(Player player)
        {
            Label isPlayingLabel = (Label) YFrom.Controls.Find("labelPlayerPlaying", true)[0];
            isPlayingLabel.Text = player.Name + " is playing";
        }
    }
}