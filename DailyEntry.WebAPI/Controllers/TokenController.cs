using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using DailyEntry.Core.Model;
using DailyEntry.Core.Services;
using DailyEntry.Core.ViewModel;


namespace DailyEntry.WebAPI.Controllers
{
    public class TokenController : ApiController
    {
        private readonly IServiceDailyTracker _service;

        public TokenController(IServiceDailyTracker serviceDailyTracker)
        {
            _service = serviceDailyTracker;
        }

        public HttpResponseMessage Post([FromBody]TokenRequestModel model)
        {
            try
            {
                var user = _service.GetApiUser(model.ApiKey);
                if (user != null)
                {
                    var secret = user.Secret;

                    // Simplistic implementation DO NOT USE
                    var key = Convert.FromBase64String(secret);
                    var provider = new System.Security.Cryptography.HMACSHA256(key);
                    // Compute Hash from API Key (NOT SECURE)
                    var hash = provider.ComputeHash(Encoding.UTF8.GetBytes(user.AppId));
                    var signature = Convert.ToBase64String(hash);

                    if (signature == model.Signature)
                    {
                        var rawTokenInfo = string.Concat(user.AppId + DateTime.UtcNow.ToString("d"));
                        var rawTokenByte = Encoding.UTF8.GetBytes(rawTokenInfo);
                        var token = provider.ComputeHash(rawTokenByte);
                        var authToken = new AuthTokenVM()
                        {
                            Token = Convert.ToBase64String(token),
                            Expiration = DateTime.UtcNow.AddDays(7),
                            ApiUser = user
                        };
                        if (_service.AddAuthToken(authToken))
                        {
                            return Request.CreateResponse(HttpStatusCode.Created, authToken);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

  
    }
}
