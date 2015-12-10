using System.Collections.Generic;
using DailyEntry.Core.Model;

namespace DailyEntry.Core.Interfaces
{
    public interface IWorkoutRepository
    {
        void CreateWorkout(Workout workout);
        void UpdateWorkout(Workout workout);
        void DeleteWorkout(Workout workout);
        void DeleteWorkout(int workoutId);
        void DeleteWorkoutByDailyFeelingId(int dailyFeelingId);
        List<Workout> GetWorkouts();
        Workout GetWorkout(int workoutId);

        //todo create new repositories
        List<WorkoutType> GetWorkoutTypes();
    }
}
