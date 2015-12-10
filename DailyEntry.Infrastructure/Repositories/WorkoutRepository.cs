using System.Collections.Generic;
using System.Linq;
using DailyEntry.Core.Interfaces;
using DailyEntry.Core.Model;

namespace DailyEntry.Infrastructure.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly TrainningDB _context;

        public WorkoutRepository(TrainningDB trainningDb)
        {
            _context = trainningDb;
        }

        public void CreateWorkout(Workout workout)
        {
            _context.Workouts.Add(workout);
        }

        public void UpdateWorkout(Workout workout)
        {
            //Todo test this well
            var workoutToUpdate = _context.Workouts.Find(workout.WorkoutId);

            if (workoutToUpdate != null)
            {
                _context.Entry(workoutToUpdate).CurrentValues.SetValues(workout);
            }
        }

        public void DeleteWorkout(Workout workout)
        {
            DeleteWorkout(workout.WorkoutId);
        }

        public void DeleteWorkout(int workoutId)
        {
            //Todo test this well
            var workoutToDelete = _context.Workouts.Find(workoutId);

            if (workoutToDelete != null)
            {
                _context.Workouts.Remove(workoutToDelete);
            }
        }

        public void DeleteWorkoutByDailyFeelingId(int dailyFeelingId)
        {
            //Todo test this well
            var workoutsToDelete = _context.Workouts.Where(w => w.DiaryFeelingId == dailyFeelingId);

            if (workoutsToDelete.Any())
            {
                foreach (var workoutToDelete in workoutsToDelete)
                {
                    _context.Workouts.Remove(workoutToDelete);
                }
            }
        }

        public List<Workout> GetWorkouts()
        {
            return _context.Workouts.ToList();
        }

        public Workout GetWorkout(int workoutId)
        {
            return _context.Workouts.FirstOrDefault(w => w.WorkoutId == workoutId);
        }

        public List<WorkoutType> GetWorkoutTypes()
        {
            return _context.WorkoutTypes.ToList();
        }


    }
}
