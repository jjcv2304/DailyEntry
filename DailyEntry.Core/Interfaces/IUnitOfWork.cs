using System;

namespace DailyEntry.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IWorkoutRepository WorkoutRepository { get; }
        IDailyFeelingRepository DiaryFeelingRepository { get; }
        ISecurityRepository SecurityRepository { get; }
        void Save();
    }
}