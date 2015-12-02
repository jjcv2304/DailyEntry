using System;
using DailyEntry.Core.Interfaces;
using DailyEntry.Infrastructure.Repositories;

namespace DailyEntry.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly TrainningDB _context;
        private IWorkoutRepository _workoutRepository;
        private IDailyFeelingRepository _diaryFeelingRepository;
        private ISecurityRepository _securityRepository;

        public UnitOfWork()
        {
            _context=new TrainningDB();
        }
        
        public IWorkoutRepository WorkoutRepository
        {
            get { return _workoutRepository ?? (_workoutRepository = new WorkoutRepository(_context)); }
        }

        public IDailyFeelingRepository DiaryFeelingRepository
        {
            get { return _diaryFeelingRepository ?? (_diaryFeelingRepository = new DailyFeelingRepository(_context)); }
        }

        public ISecurityRepository SecurityRepository
        {
            get { return _securityRepository ?? (_securityRepository = new SecurityRepository(_context)); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
