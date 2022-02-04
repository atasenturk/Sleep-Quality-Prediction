using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepTrackerUI
{
    public class SleepDetail
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public float SleepQuality { get; set; }
        public float HeartRate { get; set; }
        public float Steps { get; set; }

    }
}
