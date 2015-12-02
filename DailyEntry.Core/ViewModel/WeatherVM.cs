using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DailyEntry.Core.Model;

namespace DailyEntry.Core.ViewModel
{
    public partial class WeatherVM
    {
        public WeatherVM()
        {
           // this.tblWorkouts = new List<Workout>();
        }

        public int WeatherId { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Workout> tblWorkouts { get; set; }
    }
}
