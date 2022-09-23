using System.ComponentModel;

namespace Yahtzee
{
    partial class PlayersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.labelPlayer3 = new System.Windows.Forms.Label();
            this.labelPlayer4 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.textBoxPlayer3 = new System.Windows.Forms.TextBox();
            this.textBoxPlayer4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.Location = new System.Drawing.Point(100, 81);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(145, 16);
            this.labelPlayer1.TabIndex = 0;
            this.labelPlayer1.Text = "Player 1:";
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.Location = new System.Drawing.Point(100, 161);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(145, 16);
            this.labelPlayer2.TabIndex = 1;
            this.labelPlayer2.Text = "Player 2:";
            // 
            // labelPlayer3
            // 
            this.labelPlayer3.Location = new System.Drawing.Point(100, 241);
            this.labelPlayer3.Name = "labelPlayer3";
            this.labelPlayer3.Size = new System.Drawing.Size(145, 16);
            this.labelPlayer3.TabIndex = 2;
            this.labelPlayer3.Text = "Player 3:";
            // 
            // labelPlayer4
            // 
            this.labelPlayer4.Location = new System.Drawing.Point(100, 321);
            this.labelPlayer4.Name = "labelPlayer4";
            this.labelPlayer4.Size = new System.Drawing.Size(145, 16);
            this.labelPlayer4.TabIndex = 3;
            this.labelPlayer4.Text = "Player 4:";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(554, 297);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(145, 63);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start Game";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxPlayer1.Location = new System.Drawing.Point(100, 100);
            this.textBoxPlayer1.MaxLength = 10;
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(145, 20);
            this.textBoxPlayer1.TabIndex = 5;
            this.textBoxPlayer1.Text = "Enter name...";
            this.textBoxPlayer1.GotFocus += new System.EventHandler(this.RemoveText);
            this.textBoxPlayer1.LostFocus += new System.EventHandler(this.AddText);
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxPlayer2.Location = new System.Drawing.Point(100, 180);
            this.textBoxPlayer2.MaxLength = 10;
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(145, 20);
            this.textBoxPlayer2.TabIndex = 6;
            this.textBoxPlayer2.Text = "Enter name...";
            this.textBoxPlayer2.GotFocus += new System.EventHandler(this.RemoveText);
            this.textBoxPlayer2.LostFocus += new System.EventHandler(this.AddText);
            // 
            // textBoxPlayer3
            // 
            this.textBoxPlayer3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxPlayer3.Location = new System.Drawing.Point(100, 260);
            this.textBoxPlayer3.MaxLength = 10;
            this.textBoxPlayer3.Name = "textBoxPlayer3";
            this.textBoxPlayer3.Size = new System.Drawing.Size(145, 20);
            this.textBoxPlayer3.TabIndex = 7;
            this.textBoxPlayer3.Text = "Enter name...";
            this.textBoxPlayer3.GotFocus += new System.EventHandler(this.RemoveText);
            this.textBoxPlayer3.LostFocus += new System.EventHandler(this.AddText);
            // 
            // textBoxPlayer4
            // 
            this.textBoxPlayer4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxPlayer4.Location = new System.Drawing.Point(100, 340);
            this.textBoxPlayer4.MaxLength = 10;
            this.textBoxPlayer4.Name = "textBoxPlayer4";
            this.textBoxPlayer4.Size = new System.Drawing.Size(145, 20);
            this.textBoxPlayer4.TabIndex = 8;
            this.textBoxPlayer4.Text = "Enter name...";
            this.textBoxPlayer4.GotFocus += new System.EventHandler(this.RemoveText);
            this.textBoxPlayer4.LostFocus += new System.EventHandler(this.AddText);
            // 
            // PlayersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxPlayer4);
            this.Controls.Add(this.textBoxPlayer3);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.labelPlayer4);
            this.Controls.Add(this.labelPlayer3);
            this.Controls.Add(this.labelPlayer2);
            this.Controls.Add(this.labelPlayer1);
            this.Name = "PlayersForm";
            this.Text = "Enter Player Names";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox textBoxPlayer1;

        private System.Windows.Forms.TextBox textBoxPlayer3;
        private System.Windows.Forms.TextBox textBoxPlayer4;

        private System.Windows.Forms.TextBox textBoxPlayer2;

        private System.Windows.Forms.Button startButton;

        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.Label labelPlayer3;
        private System.Windows.Forms.Label labelPlayer4;

        #endregion
    }
}