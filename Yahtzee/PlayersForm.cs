using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Yahtzee
{
    public partial class PlayersForm : Form
    {
        public PlayersForm()
        {
            InitializeComponent();
        }

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
                            if (textBox.Text != string.Empty && textBox.Text != "Enter name...")
                            {
                                playerNames.Add(textBox.Text);
                                break;
                            }
                        }
                    }
                }
            }
            YahtzeeFrom yahtzeeFrom = new YahtzeeFrom(new Game(playerNames));
            this.Hide();
            yahtzeeFrom.Closed += (s, args) => this.Close(); 
            yahtzeeFrom.Show();
        }

        private void RemoveText(object sender, EventArgs e)
        {
            if (((TextBox) sender).Text == "Enter name...") 
            {
                ((TextBox) sender).Text = "";
                ((TextBox)sender).ForeColor = SystemColors.WindowText;
            }
        }

        private void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = "Enter name...";
                ((TextBox)sender).ForeColor = SystemColors.WindowFrame;
            }
        }
    }
}