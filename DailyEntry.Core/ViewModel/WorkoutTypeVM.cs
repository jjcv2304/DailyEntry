using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DailyEntry.Core.Model;

namespace DailyEntry.Core.ViewModel
{
    public class WorkoutTypeVM
    {
        public WorkoutTypeVM()
        {
           // this.tblWorkouts = new List<Workout>();
        }

        public int WorkoutTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
