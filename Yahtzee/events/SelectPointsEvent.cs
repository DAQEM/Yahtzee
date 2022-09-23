using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Yahtzee.events
{
    public class SelectPointsEvent
    {
        public static void labelPoints_Click(object sender, EventArgs e)
        {
            if (sender is Label clickedLabel)
            {
                Debug.Print(clickedLabel.Text);
            }
        }
    }
}