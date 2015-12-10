using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using DailyEntry.Core.Services;
using DailyEntry.Core.ViewModel;
using DailyEntry.WebAPI.Filters;
using DailyEntry.WebAPI.Services;
using System.Web.Http.Cors;

namespace DailyEntry.WebAPI.Controllers
{
    [DailyEntryAuthorize]
   // [EnableCors("*","*","*")]
    public class DailyEntryController : ApiController
    {
        private readonly IServiceDailyTracker _service;
        private readonly IDailyEntryIdentityService _identityService;

        const int MAX_PAGE_SIZE = 730;

        public DailyEntryController(IServiceDailyTracker serviceDailyTracker,
            IDailyEntryIdentityService identityService)
        {
            _service = serviceDailyTracker;
            _identityService = identityService;
        }

        //public IHttpActionResult Get(int pageSize, int page)
        public IHttpActionResult Get()
        {
            //todo implement page
            int pageSize = 10;
            int page= 1;
            if (pageSize > MAX_PAGE_SIZE)
            {
               return BadRequest(string.Format("Maximum items per page allowed is: {0}", MAX_PAGE_SIZE));
            }
            if (page < 0) page = 0;

            var dailyFeelingPage = _service.GetDailyFeelings(pageSize, page);

            var helper = new UrlHelper(Request);
            dailyFeelingPage.PrevUrl = page > 0 ? helper.Link("DailyEntry", new { page = page - 1 }) : "";
            dailyFeelingPage.NextUrl = page < dailyFeelingPage.TotalPages - 1 ? helper.Link("DailyEntry", new {pageSize = pageSize ,page = page + 1 }) : "";

             return Ok(dailyFeelingPage);
           // return dailyFeelingPage.DailyFeelingsVM;
        }

        public IHttpActionResult Get(int dailyFeelingId)
        {
            var dailyEntries = _service.GetDailyFeeling(dailyFeelingId);
            return Ok(dailyEntries);
        }

        public HttpResponseMessage Post(DailyFeelingVM dailyFeelingVM)
        {
            try
            {
                _service.AddDailyFeelingAndWorkouts(dailyFeelingVM);
                return Request.CreateResponse(HttpStatusCode.Created, dailyFeelingVM);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete([FromUri]DailyFeelingVM dailyFeelingVM)
        {
            try
            {
                _service.DeleteDailyFeelingAndWorkout(dailyFeelingVM.DailyFeelingId);
                return Request.CreateResponse(HttpStatusCode.NotImplemented);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(DailyFeelingVM dailyFeelingVM)
        {
            try
            {
                _service.EditDiaryFeelingAndWorkouts(dailyFeelingVM);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
