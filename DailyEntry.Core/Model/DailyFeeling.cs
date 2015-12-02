using System.Collections.Generic;

namespace DailyEntry.Core.Model
{
    public partial class DailyFeeling
    {
        public int DailyFeelingId { get; set; }
        public int Sleep { get; set; }
        public int Fatigue { get; set; }
        public int Stress { get; set; }
        public int Soreness { get; set; }
        public string Notes { get; set; }
        public System.DateTime Date { get; set; }
        public int? RestingHeartRate { get; set; }
        public decimal? Weight { get; set; }

        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
