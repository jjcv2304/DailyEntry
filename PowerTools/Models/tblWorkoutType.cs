using System;
using System.Collections.Generic;

namespace PowerTools.Models
{
    public partial class tblWorkoutType
    {
        public tblWorkoutType()
        {
            this.tblWorkouts = new List<tblWorkout>();
        }

        public int WorkoutTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<tblWorkout> tblWorkouts { get; set; }
    }
}
