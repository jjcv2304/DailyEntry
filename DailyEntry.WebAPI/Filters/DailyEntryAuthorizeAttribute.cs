﻿using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using DailyEntry.Core.Services;
using Ninject;
using WebMatrix.WebData;

namespace DailyEntry.WebAPI.Filters
{
    public class DailyEntryAuthorizeAttribute
      : AuthorizationFilterAttribute
    {

        #region before token
        
        public override void OnAuthorization(HttpActionContext actionContext)
        {
#if !DEBUG


            if (Thread.CurrentPrincipal.Identity.IsAuthenticated) return;

            var authHeader = actionContext.Request.Headers.Authorization;

            if (authHeader != null)
            {
                if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) &&
                    !string.IsNullOrWhiteSpace(authHeader.Parameter))
                {

                    var rawCredentials = authHeader.Parameter;
                    var encoding = Encoding.GetEncoding("iso-8859-1");
                    var credentials = encoding.GetString(Convert.FromBase64String(rawCredentials));
                    var split = credentials.Split(':');
                    var username = split[0];
                    var password = split[1];

                    if (!WebSecurity.Initialized)
                    {
                        WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId",
                            "UserName",
                            autoCreateTables: true);
                    }
                    if (WebSecurity.Login(username, password))
                    {
                        var principal = new GenericPrincipal(new GenericIdentity(username), null);
                        Thread.CurrentPrincipal = principal;
                        return;
                    }
                }
            }
            HandleUnauthorized(actionContext);
#endif
        }

        void HandleUnauthorized(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

            actionContext.Response.Headers.Add("WWW-Authenticate",
              "Basic Scheme='CountingKs' location='http://localhost:8901/account/login'");
        }

        #endregion

        #region with token

        //Token implementation
        //private bool _perUser;
        //public DailyEntryAuthorizeAttribute(bool perUser = true)
        //{
        //  _perUser = perUser;
        //}

        //[Inject]
        //public ServiceDailyTracker ServiceDailyTracker { get; set; }

        //public override void OnAuthorization(HttpActionContext actionContext)
        //{
        //  const string APIKEYNAME = "apikey";
        //  const string TOKENNAME = "token";

        //  var query = HttpUtility.ParseQueryString(actionContext.Request.RequestUri.Query);

        //  if (!string.IsNullOrWhiteSpace(query[APIKEYNAME]) && !string.IsNullOrWhiteSpace(query[TOKENNAME]))
        //  {
        //    var apikey = query[APIKEYNAME];
        //    var token = query[TOKENNAME];

        //    var authToken = ServiceDailyTracker.GetAuthToken(token);

        //    if (authToken != null && authToken.ApiUser.AppId == apikey && authToken.Expiration > DateTime.UtcNow)
        //    {
        //      if (_perUser)
        //      {
        //          if (Thread.CurrentPrincipal.Identity.IsAuthenticated) return;
        //          if (SetPrincipal(actionContext)) return;
        //      }
        //      else
        //      {
        //        return;
        //      }
        //    }
        //  }

        //  HandleUnauthorized(actionContext);
        //}

        //  private static bool SetPrincipal(HttpActionContext actionContext)
        //  {
        //      var authHeader = actionContext.Request.Headers.Authorization;

        //      if (authHeader == null) return false;
        //      if (!authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) ||
        //          string.IsNullOrWhiteSpace(authHeader.Parameter)) return false;

        //      var rawCredentials = authHeader.Parameter;
        //      var encoding = Encoding.GetEncoding("iso-8859-1");
        //      var credentials = encoding.GetString(Convert.FromBase64String(rawCredentials));
        //      var split = credentials.Split(':');
        //      var username = split[0];
        //      var password = split[1];

        //      if (!WebSecurity.Initialized)
        //      {
        //          WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName",
        //              autoCreateTables: true);
        //      }

        //      if (!WebSecurity.Login(username, password)) return false;
        //      var principal = new GenericPrincipal(new GenericIdentity(username), null);
        //      Thread.CurrentPrincipal = principal;
        //      return true;
        //  }

        //  void HandleUnauthorized(HttpActionContext actionContext)
        //{
        //  actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        //  if (_perUser)
        //  {
        //    actionContext.Response.Headers.Add("WWW-Authenticate",
        //      "Basic Scheme='CountingKs' location='http://localhost:8901/account/login'");
        //  }
        //}
        #endregion
    }
}