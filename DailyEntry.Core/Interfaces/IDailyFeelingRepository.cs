using System.Collections.Generic;
using DailyEntry.Core.Model;

namespace DailyEntry.Core.Interfaces
{
    public interface IDailyFeelingRepository
    {
        void CreateDailyFeeling(DailyFeeling dailyFeeling);
        void UpdateDailyFeeling(DailyFeeling dailyFeeling);
        void DeleteDailyFeeling(DailyFeeling dailyFeeling);
        List<DailyFeeling> GetDailyFeelings(int pageSize, int page);
        DailyFeeling GetDailyFeeling(int dailyFeelingId);
        int CountDailyFeelings();

    }
}