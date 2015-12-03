using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using DailyEntry.Core.Model;
using DailyEntry.Core.ViewModel;

namespace DailyEntry.Test.WebApi
{
    public static class MoqValues
    {

        public static List<WorkoutTypeVM> InitializeWorkingOutTypes()
        {
            var workingOutTypes = new List<WorkoutTypeVM>()
            {
                new WorkoutTypeVM() {WorkoutTypeId = 1, Name = "Swiming"},
                new WorkoutTypeVM() {WorkoutTypeId = 2, Name = "Running"},
                new WorkoutTypeVM() {WorkoutTypeId = 3, Name = "Weight Lifting"},
                new WorkoutTypeVM() {WorkoutTypeId = 4, Name = "Walk"},
                new WorkoutTypeVM() {WorkoutTypeId = 6, Name = "Ciclying"},
                new WorkoutTypeVM() {WorkoutTypeId = 7, Name = "Trekking"},
                new WorkoutTypeVM() {WorkoutTypeId = 8, Name = "Fresbee"},
                new WorkoutTypeVM() {WorkoutTypeId = 9, Name = "Tag Rugby"},
                new WorkoutTypeVM() {WorkoutTypeId = 10, Name = "Other"},
                new WorkoutTypeVM() {WorkoutTypeId = 11, Name = "Climbing"}
            };

            return workingOutTypes;
        }

        //todo add more values to get paging, at least 12
        public static List<DailyFeelingVM> GetDailyEntriesVMWithWorkouts()
        {
            var dailyFeelingWithWorkouts = new List<DailyFeelingVM>();

            var dailyFeeling1 = new DailyFeelingVM()
            {
                DailyFeelingId = 1,
                Date = new DateTime(2015, 1, 1),
                Fatigue = 5,
                Sleep = 5,
                Soreness = 4,
                Stress = 5,
                Notes = "",
                RestingHeartRate = 60,
                Weight = 69,
                WorkoutsVM = new List<WorkoutVM>()
            };
            var workoutVM1 = new WorkoutVM()
            {
                DiaryFeelingId = 1,
                WorkoutId = 1,
                WorkoutTypeId = 2,
                WorkoutTypeName = "Running",
                Distance = 13
            };
            dailyFeeling1.WorkoutsVM.Add(workoutVM1);
            dailyFeelingWithWorkouts.Add(dailyFeeling1);

            var dailyFeeling2 = new DailyFeelingVM()
            {
                DailyFeelingId = 2,
                Date = new DateTime(2015, 1, 2),
                Fatigue = 5,
                Sleep = 5,
                Soreness = 4,
                Stress = 5,
                Notes = "",
                RestingHeartRate = 60,
                Weight = (decimal)68.7,
                WorkoutsVM = new List<WorkoutVM>()
            };
            var workoutVM2 = new WorkoutVM()
            {
                DiaryFeelingId = 2,
                WorkoutId = 1,
                WorkoutTypeId = 1,
                WorkoutTypeName = "Swiming",
                Distance = 1200
            };
            dailyFeeling2.WorkoutsVM.Add(workoutVM2);
            dailyFeelingWithWorkouts.Add(dailyFeeling2);

            var dailyFeeling3 = new DailyFeelingVM()
            {
                DailyFeelingId = 3,
                Date = new DateTime(2015, 1, 3),
                Fatigue = 5,
                Sleep = 5,
                Soreness = 4,
                Stress = 5,
                Notes = "",
                RestingHeartRate = 59,
                Weight = (decimal)68.5,
                WorkoutsVM = new List<WorkoutVM>()
            };
            var workoutVM3 = new WorkoutVM()
            {
                DiaryFeelingId = 3,
                WorkoutId = 1,
                WorkoutTypeId = 1,
                WorkoutTypeName = "Swiming",
                Distance = 1200
            };
            var workoutVM4 = new WorkoutVM()
            {
                DiaryFeelingId = 3,
                WorkoutId = 1,
                WorkoutTypeId = 2,
                WorkoutTypeName = "Running",
                Distance = 12
            };
            dailyFeeling3.WorkoutsVM.Add(workoutVM3);
            dailyFeeling3.WorkoutsVM.Add(workoutVM4);
            dailyFeelingWithWorkouts.Add(dailyFeeling3);

            var dailyFeeling5 = new DailyFeelingVM()
            {
                DailyFeelingId = 5,
                Date = new DateTime(2015, 1, 5),
                Fatigue = 4,
                Sleep = 5,
                Soreness = 4,
                Stress = 5,
                Notes = "",
                RestingHeartRate = 60,
                Weight = (decimal)68.5,
                WorkoutsVM = new List<WorkoutVM>()
            };
            var workoutVM5 = new WorkoutVM()
            {
                DiaryFeelingId = 5,
                WorkoutId = 1,
                WorkoutTypeId = 1,
                WorkoutTypeName = "Swiming",
                Distance = 1200
            };
            dailyFeeling5.WorkoutsVM.Add(workoutVM5);
            dailyFeelingWithWorkouts.Add(dailyFeeling5);

            var dailyFeeling6 = new DailyFeelingVM()
            {
                DailyFeelingId = 6,
                Date = new DateTime(2015, 1, 6),
                Fatigue = 4,
                Sleep = 5,
                Soreness = 4,
                Stress = 5,
                Notes = "",
                RestingHeartRate = 60,
                Weight = (decimal)68,
                WorkoutsVM = new List<WorkoutVM>()
            };
            var workoutVM6 = new WorkoutVM()
            {
                DiaryFeelingId =6,
                WorkoutId = 1,
                WorkoutTypeId = 2,
                WorkoutTypeName = "Runnning",
                Distance = 14
            };
            dailyFeeling6.WorkoutsVM.Add(workoutVM6);
            dailyFeelingWithWorkouts.Add(dailyFeeling6);


            var dailyFeeling7 = new DailyFeelingVM()
            {
                DailyFeelingId = 7,
                Date = new DateTime(2015, 1, 7),
                Fatigue = 5,
                Sleep = 5,
                Soreness = 5,
                Stress = 5,
                Notes = "",
                RestingHeartRate = 60,
                Weight = (decimal)68.9,
                WorkoutsVM = new List<WorkoutVM>()
            };
            var workoutVM7 = new WorkoutVM()
            {
                DiaryFeelingId = 7,
                WorkoutId = 1,
                WorkoutTypeId = 1,
                WorkoutTypeName = "Swimming",
                Distance = 1200
            };
            dailyFeeling7.WorkoutsVM.Add(workoutVM7);
            dailyFeelingWithWorkouts.Add(dailyFeeling7);

            var dailyFeeling8 = new DailyFeelingVM()
            {
                DailyFeelingId = 8,
                Date = new DateTime(2015, 1, 8),
                Fatigue = 4,
                Sleep = 4,
                Soreness = 4,
                Stress = 5,
                Notes = "",
                RestingHeartRate = 60,
                Weight = (decimal)68.9,
                WorkoutsVM = new List<WorkoutVM>()
            };
            var workoutVM8 = new WorkoutVM()
            {
                DiaryFeelingId = 8,
                WorkoutId = 1,
                WorkoutTypeId = 2,
                WorkoutTypeName = "Runnning",
                Distance = 14
            };
            dailyFeeling8.WorkoutsVM.Add(workoutVM8);
            dailyFeelingWithWorkouts.Add(dailyFeeling8);


            var dailyFeeling10 = new DailyFeelingVM()
            {
                DailyFeelingId = 10,
                Date = new DateTime(2015, 1, 10),
                Fatigue = 5,
                Sleep = 5,
                Soreness = 3,
                Stress = 5,
                Notes = "",
                RestingHeartRate = 60,
                Weight = (decimal)68,
                WorkoutsVM = new List<WorkoutVM>()
            };
            var workoutVM10 = new WorkoutVM()
            {
                DiaryFeelingId = 10,
                WorkoutId = 1,
                WorkoutTypeId = 1,
                WorkoutTypeName = "Swimming",
                Distance = 1200
            };
            dailyFeeling10.WorkoutsVM.Add(workoutVM10);
            dailyFeelingWithWorkouts.Add(dailyFeeling10);

            var dailyFeeling11 = new DailyFeelingVM()
            {
                DailyFeelingId = 11,
                Date = new DateTime(2015, 1, 11),
                Fatigue = 4,
                Sleep = 4,
                Soreness = 3,
                Stress = 5,
                Notes = "",
                RestingHeartRate = 60,
                Weight = (decimal)69.5,
                WorkoutsVM = new List<WorkoutVM>()
            };
            var workoutVM11 = new WorkoutVM()
            {
                DiaryFeelingId = 11,
                WorkoutId = 1,
                WorkoutTypeId = 2,
                WorkoutTypeName = "Runnning",
                Distance = 17
            };
            dailyFeeling11.WorkoutsVM.Add(workoutVM11);
            dailyFeelingWithWorkouts.Add(dailyFeeling11);


            var dailyFeeling12 = new DailyFeelingVM()
            {
                DailyFeelingId = 12,
                Date = new DateTime(2015, 1, 12),
                Fatigue = 5,
                Sleep = 5,
                Soreness = 5,
                Stress = 5,
                Notes = "",
                RestingHeartRate = 60,
                Weight = (decimal)67.7,
                WorkoutsVM = new List<WorkoutVM>()
            };
            var workoutVM12 = new WorkoutVM()
            {
                DiaryFeelingId = 12,
                WorkoutId = 1,
                WorkoutTypeId = 1,
                WorkoutTypeName = "Swimming",
                Distance = 1200
            };
            dailyFeeling12.WorkoutsVM.Add(workoutVM12);
            dailyFeelingWithWorkouts.Add(dailyFeeling12);

            var dailyFeeling14 = new DailyFeelingVM()
            {
                DailyFeelingId = 14,
                Date = new DateTime(2015, 1, 14),
                Fatigue = 4,
                Sleep = 5,
                Soreness = 4,
                Stress = 5,
                Notes = "",
                RestingHeartRate = 60,
                Weight = (decimal)68,
                WorkoutsVM = new List<WorkoutVM>()
            };
            var workoutVM14 = new WorkoutVM()
            {
                DiaryFeelingId = 14,
                WorkoutId = 1,
                WorkoutTypeId = 2,
                WorkoutTypeName = "Runnning",
                Distance = 12
            };
            dailyFeeling14.WorkoutsVM.Add(workoutVM14);
            dailyFeelingWithWorkouts.Add(dailyFeeling14);

            return dailyFeelingWithWorkouts;
        }

        //todo implement urls, improve totals, and pages
        public static DailyFeelingPageVM GetDailyFeelingPageVM(int pageSize, int pageNumber)
        {
            var dailyFeelings = GetDailyEntriesVMWithWorkouts();
            var totalCount = dailyFeelings.Count;
            var totalPages = Math.Ceiling((double)totalCount / pageSize);
            var page = new DailyFeelingPageVM()
            {
                DailyFeelingsVM = dailyFeelings,
                TotalPages = totalPages,
                TotalCount = totalCount,
                PrevUrl = "",
                NextUrl = ""
            };
            return page;
        }

        //todo improve, see to get dinamically the routes and the rest of the configuration
        public static HttpRequestMessage GetRequest()
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                 name: "DailyEntry",
                 routeTemplate: "api/dailyEntry/{dailyEntryId}",
                 defaults: new { controller = "dailyEntry", dailyEntryId = RouteParameter.Optional }
             );

            config.Routes.MapHttpRoute(
                name: "Workout",
                routeTemplate: "api/dailyEntry/{dailyEntryId}/workout/{workoutId}",
                defaults: new { controller = "workout", id = RouteParameter.Optional }
            );

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost");
            request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            request.Properties[HttpPropertyKeys.HttpRouteDataKey] = new HttpRouteData(new HttpRoute());

            return request;
        }
    }
}
