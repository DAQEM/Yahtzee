using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Yahtzee
{
    public class Game
    {
        public YahtzeeFrom YahtzeeFrom;
        public readonly List<Player> Players = new List<Player>();
        public Turn CurrentTurn;
        
        /// <summary>Creates a new game for 1 to 4 players max.</summary>
        /// <param name="playerNames">A list of all of the names of the <see cref="Players"/> playing the game.</param>
        public Game(List<string> playerNames)
        {
            //Loop though all new players and add to players list.
            foreach (string playerName in playerNames)
            {
                AddPlayer(playerName);
            }
        }

        /// <summary>Add player to <see cref="Players"/>.</summary>
        /// <param name="playerName">The name of the player.</param>
        private void AddPlayer(string playerName)
        {
            Players.Add(new Player(playerName));
        }

        /// <summary>Gets a player based on a player number. Example: 1 is the fist player in the <see cref="Players"/> list.</summary>
        /// <param name="playerNumber"></param>
        /// <returns></returns>
        public Player GetPlayer(int playerNumber)
        {
            return Players[playerNumber - 1];
        }

        /// <summary>Gets the player paying the next turn.</summary>
        /// <returns>An instance of the player playing the next game.</returns>
        private Player GetNextPlayer()
        {
            int currentPlayerNumber = GetCurrentPlayerNumber();
            return currentPlayerNumber == Players.Count ? GetPlayer(1) : GetPlayer(currentPlayerNumber + 1);
        }
        
        /// <summary>Start the next turn for the next player.</summary>
        public void NextTurn(YahtzeeFrom yahtzeeFrom)
        {
            Player nextPlayer = GetNextPlayer();
            SetIsPlayingText(nextPlayer);
            Control[] rollsLeftLabels = yahtzeeFrom.Controls.Find("labelRollsLeft", true);
            if (rollsLeftLabels.Any())
            {
                rollsLeftLabels[0].Text = "3 rolls left.";
            }
            //Remove all dice on the table from the screen.
            foreach (Die die in CurrentTurn.TurnTable.DiceDictionary.Values)
            {
                die.DisposeFromScreen();
            }
            
            //Remove all dice in the hand from the screen.
            foreach (Die die in CurrentTurn.TurnHand.DiceDictionary.Values)
            {
                die.DisposeFromScreen();
            }

            CurrentTurn = new Turn(nextPlayer, YahtzeeFrom);
        }

        /// <summary>Prints a text on the top of the screen to tell who is playing the turn.</summary>
        /// <param name="player">The player playing the turn.</param>
        public void SetIsPlayingText(Player player)
        {
            Control[] isPlayingLabels = YahtzeeFrom.Controls.Find("labelPlayerPlaying", true);
            if (isPlayingLabels.Any())
            {
                isPlayingLabels[0].Text = player.Name + " is playing";
            }
        }

        /// <summary>Gets the player number of the player playing the current turn.</summary>
        /// <returns>The player number of the player playing the current turn.</returns>
        public int GetCurrentPlayerNumber()
        {
            return Players.FindIndex(player => player.Equals(CurrentTurn.Player)) + 1;
        }
    }
}