using System.Collections.Generic;

namespace DailyEntry.Core.Model
{
    public partial class DiaryUser
    {
        public int Id { get; set; }
        public int Username { get; set; }

        public virtual ICollection<DailyFeeling> DailyFeelings { get; set; }
    }
}