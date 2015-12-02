using System.Collections.Generic;
using System.Linq;
using DailyEntry.Core.Model;
using DailyEntry.Core.ViewModel;

namespace DailyEntry.Core.Services
{
    public static class MapMVM
    {
        //DailyFeeling
        public static DailyFeelingPageVM DiaryFeelingsToDiaryFeelingPageVM(List<DailyFeeling> diaryFeelings, int totalCount, double totalPages)
        {
            var diaryFeelingsVM = MapMVM.DiaryFeelingsToDiaryFeelingsVM(diaryFeelings);
            var dailyFeelingPageVM = new DailyFeelingPageVM()
            {
                DailyFeelingsVM = diaryFeelingsVM,
                TotalPages = totalPages,
                TotalCount = totalCount,
                NextUrl = string.Empty,
                PrevUrl = string.Empty
            };
            return dailyFeelingPageVM;
        }
        public static List<DailyFeelingVM> DiaryFeelingsToDiaryFeelingsVM(List<DailyFeeling> diaryFeelings)
        {
            var diaryFeelingsVM = from df in diaryFeelings
                                  select new DailyFeelingVM()
                                      {
                                          DailyFeelingId = df.DailyFeelingId,
                                          Date = df.Date,
                                          Fatigue = df.Fatigue,
                                          Notes = df.Notes,
                                          RestingHeartRate = df.RestingHeartRate,
                                          Sleep = df.Sleep,
                                          Soreness = df.Soreness,
                                          Stress = df.Stress,
                                          Weight = df.Weight,
                                          WorkoutsVM = (from w in df.Workouts
                                                       select new WorkoutVM()
                                                           {
                                                               WorkoutId = w.WorkoutId,                                                               
                                                               Date = w.Date,
                                                               Distance = w.Distance,
                                                               Notes = w.Notes,
                                                               RouteId = w.RouteId,
                                                               RouteName = w.Route.Name,
                                                               Time = w.Time,
                                                               TotalTime = w.TotalTime,
                                                               WorkoutTypeId = w.WorkoutTypeId,
                                                               WorkoutTypeName = w.WorkoutType.Name,
                                                           }).ToList()
                                      };
            return diaryFeelingsVM.ToList();
        }

        public static DailyFeeling DiaryFeelingVMToDiaryFeeling(DailyFeelingVM df)
        {
            var diaryFeeling = new DailyFeeling()
                                  {
                                      DailyFeelingId = df.DailyFeelingId,
                                      Date = df.Date,
                                      Fatigue = df.Fatigue,
                                      Notes = df.Notes,
                                      RestingHeartRate = df.RestingHeartRate,
                                      Sleep = df.Sleep,
                                      Soreness = df.Soreness,
                                      Stress = df.Stress,
                                      Weight = df.Weight
                                  };
            return diaryFeeling;
        }
        
        public static DailyFeelingVM DiaryFeelingToDiaryFeelingVM(DailyFeeling df)
        {
            var diaryFeeling = new DailyFeelingVM()
            {
                DailyFeelingId = df.DailyFeelingId,
                Date = df.Date,
                Fatigue = df.Fatigue,
                Notes = df.Notes,
                RestingHeartRate = df.RestingHeartRate,
                Sleep = df.Sleep,
                Soreness = df.Soreness,
                Stress = df.Stress,
                Weight = df.Weight
            };
            return diaryFeeling;
        }

        //Workout
        public static List<WorkoutTypeVM> WorkoutTypeToWorkoutTypeVM(List<WorkoutType> workoutTypes)
        {
            var workoutTypesvm = from wt in workoutTypes
                                 select new WorkoutTypeVM()
                                     {
                                         Description = wt.Description,
                                         Name = wt.Name,
                                         WorkoutTypeId = wt.WorkoutTypeId
                                     };
            return workoutTypesvm.ToList();
        }

        public static Workout WorkoutToWorkoutVM(WorkoutVM workoutVM)
        {
            var workout = new Workout()
            {
                WorkoutId = workoutVM.WorkoutId,
                Date = workoutVM.Date,
                Time = workoutVM.Time,
                Distance = workoutVM.Distance,
                TotalTime = workoutVM.TotalTime,
                Notes = workoutVM.Notes,
                DiaryFeelingId = workoutVM.DiaryFeelingId,
                RouteId = workoutVM.RouteId,
                WorkoutTypeId = workoutVM.WorkoutTypeId
            };
            return workout;
        }

        //Route
        public static List<RouteVM> RouteToRouteVM(List<Route> routes)
        {
            var routesvm = from r in routes
                           select new RouteVM()
                               {
                                   RouteId = r.RouteId,
                                   Name = r.Name,
                                   Description = r.Description
                               };
            return routesvm.ToList();
        }


        public static AuthToken AuthTokenVMToAuthToken(AuthTokenVM authTokenVM)
        {
            var authToken = new AuthToken()
            {
                Expiration = authTokenVM.Expiration,
                Token = authTokenVM.Token,
                ApiUser = authTokenVM.ApiUser
            };
            return authToken;
        }
    }
}
