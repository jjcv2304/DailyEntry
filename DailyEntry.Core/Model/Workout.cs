using System;

namespace DailyEntry.Core.Model
{
    public partial class Workout
    {
        public int WorkoutId { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan Time { get; set; }
        public int WorkoutTypeId { get; set; }
        public int? WeatherId { get; set; }
        public int? RouteId { get; set; }
        public decimal? Distance { get; set; }
        public TimeSpan? TimeSpend { get; set; }
        public TimeSpan? TotalTime { get; set; }
        public TimeSpan? TimeZone1 { get; set; }
        public TimeSpan? TimeZone2 { get; set; }
        public TimeSpan? TimeZone3 { get; set; }
        public TimeSpan? TimeZone4 { get; set; }
        public TimeSpan? TimeZone5 { get; set; }
        public string Notes { get; set; }
        public int? Temperature { get; set; }
        public int? DiaryFeelingId { get; set; }
        public virtual DailyFeeling DiaryFeeling { get; set; }
        public virtual Route Route { get; set; }
        public virtual Weather Weather { get; set; }
        public virtual WorkoutType WorkoutType { get; set; }
    }
}
