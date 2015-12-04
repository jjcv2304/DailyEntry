using System;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using System.Web.Mvc;
using System.Web.Routing;
using DailyEntry.Core.Model;
using DailyEntry.Core.Services;
using DailyEntry.Core.ViewModel;
using DailyEntry.WebAPI;
using DailyEntry.WebAPI.Controllers;
using DailyEntry.WebAPI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UrlHelper = System.Web.Http.Routing.UrlHelper;

namespace DailyEntry.Test.WebApi
{
    [TestClass]
    public class DailyEntry
    {
        private HttpRequestMessage _request = null;

        [TestInitialize]
        public void Initializer()
        {
            //_request = MoqValues.GetRequest();
            _request = MoqValues.GetRequest();
        }

        [TestMethod]
        public void GetDailyFeelings()
        {
            ////Arrange
            //var itemsPerParge = 5;
            //var pageNumber = 1;
            //var service = new Mock<IServiceDailyTracker>();
            //var identityService = new Mock<IDailyEntryIdentityService>();

            //var page =MoqValues.GetDailyFeelingPageVM(itemsPerParge, pageNumber);//todo improve, pass page
            //service.Setup(s => s.GetDailyFeelings(It.IsAny<int>(), It.IsAny<int>())).Returns(page);

            ////Act
            //var controller = new DailyEntryController(service.Object, identityService.Object) {Request = _request};

            //var actionResult = controller.Get(itemsPerParge, pageNumber);

            ////Assert
            ////todo search strategy for doing below checks, just one method or multiple?
            //Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<DailyFeelingPageVM>));
            //var content = ((OkNegotiatedContentResult<DailyFeelingPageVM>)actionResult).Content;
            //Assert.AreEqual(content.TotalCount, content.DailyFeelingsVM.Count);
            //Assert.IsTrue(content.TotalPages == (Math.Ceiling((double)content.DailyFeelingsVM.Count/ (double)itemsPerParge)));
        }






    }
}
