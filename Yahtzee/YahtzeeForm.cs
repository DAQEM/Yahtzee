using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Yahtzee;
using Yahtzee.events;

namespace Yahtzee
{
    public partial class YahtzeeFrom : Form
    {
        public readonly Game Game;
        public readonly Random SynchronizedRandom = new Random();
        
        public YahtzeeFrom(Game game)
        {
            this.Game = game;
            this.Game.YFrom = this;
            InitializeComponent();
            SetPlayerNames();
            DisposeUnusedLabels();
        }

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

        private void labelPoints_Click(object sender, EventArgs e)
        {
            SelectPointsEvent.labelPoints_Click(sender, e);
        }

        private void buttonRollDice_Click(object sender, EventArgs e)
        {
            RollDiceEvent.ButtonRollDiceClick(sender, e, this);
        }

        public void dice_Click(object sender, EventArgs e)
        {
            SelectDiceEvent.dice_Click(sender, e, this);
        }
    }
}