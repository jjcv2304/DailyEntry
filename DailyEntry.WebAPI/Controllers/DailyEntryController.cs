using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using DailyEntry.Core.Services;
using DailyEntry.Core.ViewModel;
using DailyEntry.WebAPI.Filters;
using DailyEntry.WebAPI.Services;

namespace DailyEntry.WebAPI.Controllers
{
    [DailyEntryAuthorize]
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

        public HttpResponseMessage Get(int pageSize, int page)
        {
            if (pageSize > MAX_PAGE_SIZE)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    string.Format("Maximum items per page allowed is: {0}", MAX_PAGE_SIZE));
            }
            if (page < 0) page = 0;

            var dailyFeelingPage = _service.GetDailyFeelings(pageSize, page);

            var helper = new UrlHelper(Request);
            dailyFeelingPage.PrevUrl = page > 0 ? helper.Link("DailyEntry", new { page = page - 1 }) : "";
            dailyFeelingPage.NextUrl = page < dailyFeelingPage.TotalPages - 1 ? helper.Link("DailyEntry", new {pageSize = pageSize ,page = page + 1 }) : "";

            return Request.CreateResponse(HttpStatusCode.OK, dailyFeelingPage);
        }

        public HttpResponseMessage Get(int dailyFeelingId)
        {
            var dailyEntries = _service.GetDailyFeeling(dailyFeelingId);
            return Request.CreateResponse(HttpStatusCode.OK, dailyEntries);
        }

        public HttpResponseMessage Post(DailyFeelingVM dailyFeelingVM)
        {
            try
            {
                _service.AddDailyFeelingAndWorkout(dailyFeelingVM);
                return Request.CreateResponse(HttpStatusCode.Created, dailyFeelingVM);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int dailyFeelingId)
        {
            try
            {
                _service.DeleteDailyFeelingAndWorkout(dailyFeelingId);
                return Request.CreateResponse(HttpStatusCode.NotImplemented);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [HttpPatch]
        public HttpResponseMessage Patch(DailyFeelingVM dailyFeelingVM)
        {
            try
            {
                _service.EditDiaryFeeling(dailyFeelingVM);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
