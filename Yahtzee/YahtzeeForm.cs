using System;
using System.Windows.Forms;
using Yahtzee.events;

namespace Yahtzee
{
    public partial class YahtzeeFrom : Form
    {
        public readonly Game Game;
        public readonly Random SynchronizedRandom = new Random();
        
        /// <summary>Creates a new YahtzeeForm</summary>
        /// <param name="game">The game containing the payers playing the game.</param>
        public YahtzeeFrom(Game game)
        {
            Game = game;
            Game.YahtzeeFrom = this;
            InitializeComponent();
            SetPlayerNames();
            DisposeUnusedLabels();
            
            //Set first turn for Player 1
            Game.CurrentTurn = new Turn(Game.Players[0], this);
        }

        /// <summary>Print the player names to the top of the points board.</summary>
        private void SetPlayerNames()
        {
            //Loop though all players
            for (int playerNumber = 1; playerNumber <= Game.Players.Count; playerNumber++)
            {
                Player player = Game.GetPlayer(playerNumber);
                Label playerLabel = (Label) Controls.Find("labelPlayer" + playerNumber, true)[0];
                
                playerLabel.Text = player.Name;
            }
            
            Game.SetIsPlayingText(Game.GetPlayer(1));
            
        }

        /// <summary>Disposes all of the unused labels of the players who are not playing.</summary>
        private void DisposeUnusedLabels()
        {
            //Loop through all unused players
            for (int playerNumber = Game.Players.Count + 1; playerNumber <= Constants.MaxPlayers ; playerNumber++)
            {
                //Loop though all Player Based Labels
                foreach (string playerBasedLabelName in Constants.PlayerBasedLabels)
                {
                    Controls.Find(playerBasedLabelName + playerNumber, true)[0].Dispose();
                }
            }
        }

        /// <summary>Passed the event to a dedicated class.</summary>
        /// <param name="sender">The clicked label.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void labelPoints_Click(object sender, EventArgs e)
        {
            SelectPointsEvent.labelPoints_Click(sender, e, this);
        }

        /// <summary>Passed the event to a dedicated class.</summary>
        /// <param name="sender">The clicked button.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonRollDice_Click(object sender, EventArgs e)
        {
            RollDiceEvent.ButtonRollDiceClick(sender, e, this);
        }

        /// <summary>Passed the event to a dedicated class.</summary>
        /// <param name="sender">The clicked die label.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void dice_Click(object sender, EventArgs e)
        {
            SelectDiceEvent.dice_Click(sender, e, this);
        }
    }
}