using System;
using System.Drawing;
using System.Windows.Forms;

namespace Yahtzee
{
    public class Die
    {
        public readonly int Pips;
        public readonly Label DieLabel = new Label();

        public Die(YahtzeeFrom form, int position) : this(form, position, form.SynchronizedRandom.Next(1, 7))
        {
        }

        public Die(YahtzeeFrom form, int position, int pips, int yOffset = Constants.TableY)
        {
            Pips = pips;
            Image image = Image.FromFile($"../../images/dice{pips}.png");
            DieLabel.Size = new Size(image.Width, image.Height);
            DieLabel.Location = new Point(Constants.TableStartX + Constants.SpaceBetweenDice * (position - 1), yOffset);
            DieLabel.Image = image;
            DieLabel.Click += form.dice_Click;
            DieLabel.Name = Guid.NewGuid().ToString();
            form.Controls.Add(DieLabel);
        }

        public void RemoveFromScreen()
        {
            DieLabel.Dispose();
        }
    }
}