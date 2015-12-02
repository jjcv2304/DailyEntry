using System.Collections.Generic;

namespace DailyEntry.Core.Model
{
    public partial class Route
    {
        public Route()
        {
           // this.tblWorkouts = new List<Workout>();
        }

        public int RouteId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Workout> tblWorkouts { get; set; }
    }
}
