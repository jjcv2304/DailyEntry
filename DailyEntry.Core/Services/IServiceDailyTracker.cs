using System.Collections.Generic;
using DailyEntry.Core.Model;
using DailyEntry.Core.ViewModel;

namespace DailyEntry.Core.Services
{
    public interface IServiceDailyTracker
    {

        //Graph
        void AddDailyFeelingAndWorkouts(DailyFeelingVM dailyFeelingVM);
        void DeleteDailyFeelingAndWorkout(int dailyFeelingId);

        //DailyFeeling
        DailyFeelingVM GetDailyFeeling(int dailyFeelingId);
        DailyFeelingPageVM GetDailyFeelings(int pageSize, int page);
        void AddDailyFeeling(DailyFeelingVM diaryFeelingVM);        
        void EditDiaryFeelingAndWorkouts(DailyFeelingVM dailyFeelingVM);
        
        //Workout
        void AddWorkout(WorkoutVM workoutVM);
        void EditWorkout(WorkoutVM workoutVM);
        void DeleteWorkout(int workoutId);
        
        //WorkoutType
        List<WorkoutTypeVM> GetWorkoutTypes();

        //Security
        ApiUser GetApiUser(string apiKey);
        bool AddAuthToken(AuthTokenVM authToken);
        AuthToken GetAuthToken(string token);
    }
}