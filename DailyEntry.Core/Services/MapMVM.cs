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
                                                               Distance = w.Distance,
                                                               Notes = w.Notes,
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
                                      Weight = df.Weight,
                Workouts = df.WorkoutsVM==null ? null: (from w in df.WorkoutsVM
                              select new Workout()
                              {
                                  WorkoutId = w.WorkoutId,
                                  Distance = w.Distance,
                                  Notes = w.Notes,
                                  TotalTime = w.TotalTime,
                                  WorkoutTypeId = w.WorkoutTypeId
                              }).ToList()
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
                Weight = df.Weight,
                WorkoutsVM = WorkoutToWorkoutVM(df.Workouts)
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


        public static List<WorkoutVM> WorkoutToWorkoutVM(ICollection<Workout> workouts)
        {
           var  workoutsVM = workouts== null ? null : (from w in workouts
                         select new WorkoutVM()
                         {
                             WorkoutId = w.WorkoutId,
                             Distance = w.Distance,
                             TotalTime = w.TotalTime,
                             Notes = w.Notes,
                             DiaryFeelingId = w.DiaryFeelingId,
                             WorkoutTypeId = w.WorkoutTypeId,
                             WorkoutTypeName = w.WorkoutType.Name
                         }).ToList();
            return workoutsVM;
        }

        public static Workout WorkoutToWorkoutVM(WorkoutVM workoutVM)
        {
            var workout = new Workout()
            {
                WorkoutId = workoutVM.WorkoutId,
                Distance = workoutVM.Distance,
                TotalTime = workoutVM.TotalTime,
                Notes = workoutVM.Notes,
                DiaryFeelingId = workoutVM.DiaryFeelingId,
                WorkoutTypeId = workoutVM.WorkoutTypeId
            };
            return workout;
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
