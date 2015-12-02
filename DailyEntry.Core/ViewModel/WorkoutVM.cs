using System;
using DailyEntry.Core.Model;

namespace DailyEntry.Core.ViewModel
{
    public class WorkoutVM
    {
        public int WorkoutId { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan Time { get; set; }
        public decimal? Distance { get; set; }
        public TimeSpan? TotalTime { get; set; }
        public string Notes { get; set; }      
        public int? DiaryFeelingId { get; set; }
        public int? RouteId { get; set; }
        public string RouteName { get; set; }
        public virtual Route Route { get; set; }
        public int WorkoutTypeId { get; set; }
        public string WorkoutTypeName { get; set; }
        public virtual WorkoutType WorkoutType { get; set; }

        // public virtual DiaryFeeling DiaryFeeling { get; set; }
        //  public int? Temperature { get; set; }
        //  public Nullable<int> WeatherId { get; set; }
        //public Nullable<System.TimeSpan> TimeSpend { get; set; }
        //public Nullable<System.TimeSpan> TimeZone1 { get; set; }
        //public Nullable<System.TimeSpan> TimeZone2 { get; set; }
        //public Nullable<System.TimeSpan> TimeZone3 { get; set; }
        //public Nullable<System.TimeSpan> TimeZone4 { get; set; }
        //public Nullable<System.TimeSpan> TimeZone5 { get; set; }
        // public virtual Weather Weather { get; set; }
    }
}
