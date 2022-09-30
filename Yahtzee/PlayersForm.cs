using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Yahtzee
{
    public partial class PlayersForm : Form
    {
        public PlayersForm()
        {
            InitializeComponent();
        }

        /// <summary>The event fired when the game start button is clicked</summary>
        /// <param name="sender">The button clicked.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void startButton_Click(object sender, EventArgs e)
        {
            List<string> playerNames = new List<string>();
            for (int i = 1; i <= Constants.MaxPlayers; ++i)
            {
                foreach (Control control in Controls)
                {
                    if (control is TextBox textBox)
                    {
                        if (textBox.Name == "textBoxPlayer" + i)
                        {
                            if (textBox.Text != string.Empty && textBox.Text != Constants.EnterNameText)
                            {
                                playerNames.Add(textBox.Text);
                                break;
                            }
                        }
                    }
                }
            }

            //Check if the list contains player names and start the game is true.
            if (playerNames.Any())
            {
                YahtzeeFrom yahtzeeFrom = new YahtzeeFrom(new Game(playerNames));
                this.Hide();
                yahtzeeFrom.Closed += (s, args) => this.Close(); 
                yahtzeeFrom.Show();
            }
        }

        /// <summary>Fired then the TextBox gains focus. Removes the 'Enter name...' text from the TextBox.</summary>
        /// <param name="sender">the clicked TextBox</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RemoveText(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == Constants.EnterNameText) 
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText;
            }
        }

        /// <summary>Fired then the TextBox loses focus. Adds the 'Enter name...' text to the TextBox when the TextBox is empty.</summary>
        /// <param name="sender"></param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AddText(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = Constants.EnterNameText;
                textBox.ForeColor = SystemColors.WindowFrame;
            }
        }
    }
}