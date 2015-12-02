using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DailyEntry.Core.Services;
using DailyEntry.Core.ViewModel;
using DailyEntry.WebAPI.Filters;
using DailyEntry.WebAPI.Services;

namespace DailyEntry.WebAPI.Controllers
{
    [DailyEntryAuthorize]
    public class WorkoutController : ApiController
    {
        private readonly IServiceDailyTracker _service;
        private readonly IDailyEntryIdentityService _identityService;

        public WorkoutController(IServiceDailyTracker serviceDailyTracker,
            IDailyEntryIdentityService identityService)
        {
            _service = serviceDailyTracker;
            _identityService = identityService;
        } 

        public HttpResponseMessage Post(WorkoutVM workoutVM)
        {
            try
            {
                if (workoutVM.DiaryFeelingId == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "A workout without dialy feeling id can't be added to the system");
                }
                _service.AddWorkout(workoutVM);
                return Request.CreateResponse(HttpStatusCode.Created, workoutVM);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int workoutId)
        {
            try
            {
                _service.DeleteWorkout(workoutId);
                return Request.CreateResponse(HttpStatusCode.NotImplemented);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [HttpPatch]
        public HttpResponseMessage Patch(WorkoutVM workoutVM)
        {
            try
            {
                _service.EditWorkout(workoutVM);
                return Request.CreateResponse(HttpStatusCode.NotImplemented);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
