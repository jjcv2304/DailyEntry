using System;

namespace DailyEntry.Core.Model
{
    public partial class Workout
    {
        public int WorkoutId { get; set; }
        public int WorkoutTypeId { get; set; }
        public decimal? Distance { get; set; }
        public TimeSpan? TotalTime { get; set; }
        public string Notes { get; set; }
        public int? DiaryFeelingId { get; set; }
        public virtual DailyFeeling DiaryFeeling { get; set; }
        public virtual WorkoutType WorkoutType { get; set; }
    }
}
