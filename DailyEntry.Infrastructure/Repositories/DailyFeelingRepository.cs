using System.Collections.Generic;
using System.Linq;
using DailyEntry.Core.Interfaces;
using DailyEntry.Core.Model;

namespace DailyEntry.Infrastructure.Repositories
{
    public class DailyFeelingRepository : IDailyFeelingRepository
    {
        private readonly TrainningDB _context;

        public DailyFeelingRepository(TrainningDB trainningDb)
        {
            _context = trainningDb;
        }

        public void CreateDailyFeeling(DailyFeeling dailyFeeling)
        {
            _context.DailyFeelings.Add(dailyFeeling);
        }

        public void UpdateDailyFeeling(DailyFeeling dailyFeeling)
        {
            //Todo test this well
            var diaryFeelingToUpdate = _context.DailyFeelings.FirstOrDefault(d => d.DailyFeelingId == dailyFeeling.DailyFeelingId);

            if (diaryFeelingToUpdate != null)
            {
                _context.Entry(diaryFeelingToUpdate).CurrentValues.SetValues(dailyFeeling);
            }
        }

        public void DeleteDailyFeeling(DailyFeeling dailyFeeling)
        {
            //Todo test this well
            var diaryFeelingToDelete = _context.DailyFeelings.FirstOrDefault(d => d.DailyFeelingId == dailyFeeling.DailyFeelingId);

            if (diaryFeelingToDelete != null)
            {
                _context.DailyFeelings.Remove(diaryFeelingToDelete);
            }
        }

        public List<DailyFeeling> GetDailyFeelings()
        {
            return _context.DailyFeelings.ToList();
        }

        public List<DailyFeeling> GetDailyFeelings(int pageSize, int page)
        {
            return _context.DailyFeelings
                .Include("Workouts")
                .Include("Workouts.WorkoutType")
                .OrderByDescending(d => d.Date)
                .Skip(pageSize * (page-1))
                .Take(pageSize)
                .ToList();
        }

        public DailyFeeling GetDailyFeeling(int dailyFeelingId)
        {
            return _context.DailyFeelings
                .Include("Workouts")
                .Include("Workouts.WorkoutType")
                .FirstOrDefault(d => d.DailyFeelingId == dailyFeelingId);
        }

        public int CountDailyFeelings()
        {
            return _context.DailyFeelings.Count();
        }
    }
}
