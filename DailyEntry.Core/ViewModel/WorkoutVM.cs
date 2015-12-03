using System;
using DailyEntry.Core.Model;

namespace DailyEntry.Core.ViewModel
{
    public class WorkoutVM
    {
        public int WorkoutId { get; set; }
        public decimal? Distance { get; set; }
        public TimeSpan? TotalTime { get; set; }
        public string Notes { get; set; }      
        public int? DiaryFeelingId { get; set; }
        public int WorkoutTypeId { get; set; }
        public string WorkoutTypeName { get; set; }

    }
}
