using System.Collections.Generic;
using DailyEntry.Core.ViewModel;

namespace DailyEntry.Core.Model
{
    public class DailyFeelingPageVM
    {
        public List<DailyFeelingVM> DailyFeelingsVM { get; set; }

        public int TotalCount { get; set; }
        public double TotalPages { get; set; }
        public string PrevUrl { get; set; }
        public string NextUrl { get; set; }
    }
}
