using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SleepTrackerUI
{
    public partial class DetailedSleepDesign : UserControl
    {
        public DetailedSleepDesign()
        {
            InitializeComponent();
        }

        public void setLabelStart(string start)
        {
            lblStart.Text = start;
        }

        public void setLabelEnd(string end)
        {
            lblEnd.Text = end;
        }

        public void setLabelQuality(string quality)
        {
            lblQuality.Text = "% " + quality;
        }

        public void setLabelHeart(string rate)
        {
            lblHeartRate.Text = rate;
        }

        public void setLabelSteps(string steps)
        {
            lblSteps.Text = steps;
        }
    }
}
