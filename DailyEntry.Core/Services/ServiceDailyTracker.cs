using System;
using System.Collections.Generic;
using System.Linq;
using DailyEntry.Core.Interfaces;
using DailyEntry.Core.Model;
using DailyEntry.Core.ViewModel;


namespace DailyEntry.Core.Services
{

    public class ServiceDailyTracker : IServiceDailyTracker
    {
        private readonly IUnitOfWork _uow;

        public ServiceDailyTracker(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        //DailyFeelings
        public DailyFeelingPageVM GetDailyFeelings(int pageSize, int page)
        {
            var diaryFeelings = _uow.DiaryFeelingRepository.GetDailyFeelings(pageSize, page);

            var totalCount = _uow.DiaryFeelingRepository.CountDailyFeelings();
            var totalPages = Math.Ceiling((double)totalCount / pageSize);

            return MapMVM.DiaryFeelingsToDiaryFeelingPageVM(diaryFeelings, totalCount, totalPages);
        }
        public DailyFeelingVM GetDailyFeeling(int dailyFeelingId)
        {
            var diaryFeeling = _uow.DiaryFeelingRepository.GetDailyFeeling(dailyFeelingId);
            return MapMVM.DiaryFeelingToDiaryFeelingVM(diaryFeeling);
        }
        public void AddDailyFeeling(DailyFeelingVM diaryFeelingVM)
        {
            var diaryEntry = MapMVM.DiaryFeelingVMToDiaryFeeling(diaryFeelingVM);
            _uow.DiaryFeelingRepository.CreateDailyFeeling(diaryEntry);
            _uow.Save();
        }

        //DailyFeelings Graph
        public void AddDailyFeelingAndWorkouts(DailyFeelingVM dailyFeelingVM)
        {
            var dailyFeeling = MapMVM.DiaryFeelingVMToDiaryFeeling(dailyFeelingVM);
            _uow.DiaryFeelingRepository.CreateDailyFeeling(dailyFeeling);
            AddWorkouts(dailyFeeling);
            _uow.Save();
            dailyFeelingVM = MapMVM.DiaryFeelingToDiaryFeelingVM(dailyFeeling);
        }
        public void EditDiaryFeelingAndWorkouts(DailyFeelingVM dailyFeelingVM)
        {
            var dailyFeeling = MapMVM.DiaryFeelingVMToDiaryFeeling(dailyFeelingVM);
            _uow.DiaryFeelingRepository.UpdateDailyFeeling(dailyFeeling);
            UpdateWorkouts(dailyFeeling);
            _uow.Save();
            dailyFeelingVM = MapMVM.DiaryFeelingToDiaryFeelingVM(dailyFeeling);
        }

        private void UpdateWorkouts(DailyFeeling dailyFeeling)
        {
            var dailyFeelingCurrent = _uow.DiaryFeelingRepository.GetDailyFeeling(dailyFeeling.DailyFeelingId);
            if (dailyFeelingCurrent.Workouts == null || !dailyFeelingCurrent.Workouts.Any())
            {
                AddWorkouts(dailyFeeling);
                return;
            }

            var isUpdate = false;
            foreach (var workoutCurrent in dailyFeelingCurrent.Workouts)
            {
                foreach (var workout in dailyFeeling.Workouts)
                {
                    if (workoutCurrent.WorkoutId == workout.WorkoutId)
                    {
                        //UpdateWorkout(workout);
                        isUpdate = true;
                    }
                }
                if (!isUpdate)
                {
                    //DeleteWorkout(workoutCurrent);
                }
                isUpdate = false;
            }
            var isCreate = true;
            foreach (var workout in dailyFeeling.Workouts)
            {
                foreach (var workoutCurrent in dailyFeelingCurrent.Workouts)
                {
                    if (workoutCurrent.WorkoutId == workout.WorkoutId)
                    {
                        isCreate = false;
                    }
                }
                if (isCreate)
                {
                    //AddWorkout(workout);
                }
            }

        }

        private void AddWorkouts(DailyFeeling dailyFeeling)
        {
            if (dailyFeeling.Workouts != null && dailyFeeling.Workouts.Count > 0)
            {
                foreach (var workout in dailyFeeling.Workouts)
                {
                    workout.DiaryFeelingId = dailyFeeling.DailyFeelingId;
                    _uow.WorkoutRepository.CreateWorkout(workout);
                }
            }
        }
        private void DeleteWorkoutByDailyFeelingId(int dailyFeelingId)
        {
            _uow.WorkoutRepository.DeleteWorkoutByDailyFeelingId(dailyFeelingId);
        }
        public void DeleteDailyFeelingAndWorkout(int dailyFeelingId)
        {
            var dailyFeeling = _uow.DiaryFeelingRepository.GetDailyFeeling(dailyFeelingId);
            if (dailyFeeling == null) throw new Exception("Id doesn't exists");

            if (dailyFeeling.Workouts != null && dailyFeeling.Workouts.Count > 0)
            {
                foreach (var workout in dailyFeeling.Workouts)
                {
                    workout.DiaryFeelingId = dailyFeeling.DailyFeelingId;
                    if (workout.WorkoutId != 0)
                    {
                        _uow.WorkoutRepository.DeleteWorkout(workout);
                    }
                }
            }
            _uow.DiaryFeelingRepository.DeleteDailyFeeling(dailyFeeling);

            _uow.Save();
        }

        //Workouts
        public List<WorkoutTypeVM> GetWorkoutTypes()
        {
            var workoutTypes = _uow.WorkoutRepository.GetWorkoutTypes();
            return MapMVM.WorkoutTypeToWorkoutTypeVM(workoutTypes);
        }
        public void AddWorkout(WorkoutVM workoutVM)
        {
            var workout = MapMVM.WorkoutToWorkoutVM(workoutVM);
            _uow.WorkoutRepository.CreateWorkout(workout);
            _uow.Save();
        }
        public void EditWorkout(WorkoutVM workoutVM)
        {
            var workout = MapMVM.WorkoutToWorkoutVM(workoutVM);
            _uow.WorkoutRepository.UpdateWorkout(workout);
            _uow.Save();
        }
        public void DeleteWorkout(int workoutId)
        {
            _uow.WorkoutRepository.DeleteWorkout(workoutId);
            _uow.Save();
        }

        //Security
        public ApiUser GetApiUser(string apiKey)
        {
            return _uow.SecurityRepository.GetApiUser(apiKey);
        }
        public bool AddAuthToken(AuthTokenVM authTokenVM)
        {
            //todo delete old tokens/expired
            var authToken = MapMVM.AuthTokenVMToAuthToken(authTokenVM);
            _uow.SecurityRepository.AddAuthToken(authToken);
            return true;
        }

        public AuthToken GetAuthToken(string token)
        {
            return _uow.SecurityRepository.GetAuthToken(token);
        }
    }
}
