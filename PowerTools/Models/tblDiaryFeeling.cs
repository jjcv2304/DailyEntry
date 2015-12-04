using System;
using System.Collections.Generic;

namespace PowerTools.Models
{
    public partial class tblDiaryFeeling
    {
        public tblDiaryFeeling()
        {
            this.tblWorkouts = new List<tblWorkout>();
        }

        public int DiaryFeelingId { get; set; }
        public int Sleep { get; set; }
        public int Fatigue { get; set; }
        public int Stress { get; set; }
        public int Soreness { get; set; }
        public string Notes { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> RestingHeartRate { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<int> DiaryUserId { get; set; }
        public virtual DiaryUser DiaryUser { get; set; }
        public virtual ICollection<tblWorkout> tblWorkouts { get; set; }
    }
}
