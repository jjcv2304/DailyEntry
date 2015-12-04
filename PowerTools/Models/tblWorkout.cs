using System;
using System.Collections.Generic;

namespace PowerTools.Models
{
    public partial class tblWorkout
    {
        public int WorkoutId { get; set; }
        public int WorkoutTypeId { get; set; }
        public Nullable<int> WeatherId { get; set; }
        public Nullable<int> RouteId { get; set; }
        public Nullable<decimal> Distance { get; set; }
        public Nullable<System.TimeSpan> TotalTime { get; set; }
        public string Notes { get; set; }
        public Nullable<int> DiaryFeelingId { get; set; }
        public virtual tblDiaryFeeling tblDiaryFeeling { get; set; }
        public virtual tblWorkoutType tblWorkoutType { get; set; }
    }
}
