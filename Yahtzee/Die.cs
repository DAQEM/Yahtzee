using System;
using System.Drawing;
using System.Windows.Forms;

namespace Yahtzee
{
    public class Die
    {
        public readonly int Pips;
        public readonly Label DieLabel = new Label();
        
        ///<summary>Creates a new die with random number of pips.</summary>
        /// <param name="form">The YahtzeeFrom the die should be created on.</param>
        /// <param name="position">The position the die should be on. 1 of all the way on the left, 5 is all the way on the right.</param>
        public Die(YahtzeeFrom form, int position) : this(form, position, form.SynchronizedRandom.Next(1, 7))
        {
        }

        ///<summary>Creates a new die with existing number of pips</summary>
        /// <param name="form">The YahtzeeFrom the die should be created on.</param>
        /// <param name="position">The position the die should be on. 1 of all the way on the left, 5 is all the way on the right.</param>
        /// <param name="pips">The number of pips the die should have.</param>
        /// <param name="yOffset">The amount the die should be offset on the Y axis. <see cref="Constants.TableY"/> and <see cref="Constants.HandY"/></param>
        public Die(YahtzeeFrom form, int position, int pips, int yOffset = Constants.TableY)
        {
            //assigns the number of pips
            Pips = pips;
            
            //Create new Label for the die
            Image image = Image.FromFile($"../../images/dice{pips}.png");
            DieLabel.Image = image;
            DieLabel.Size = new Size(image.Width, image.Height);
            DieLabel.Location = new Point(Constants.DieStartX + Constants.SpaceBetweenDice * (position - 1), yOffset);
            DieLabel.Name = Guid.NewGuid().ToString();
            DieLabel.Click += form.dice_Click;
            
            //Add the label to the Yahtzee form
            form.Controls.Add(DieLabel);
        }

        ///<summary>Disposes the die from the YahtzeeForm</summary>
        public void DisposeFromScreen()
        {
            DieLabel.Dispose();
        }
    }
}