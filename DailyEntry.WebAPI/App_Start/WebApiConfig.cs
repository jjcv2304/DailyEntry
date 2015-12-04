using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using WebApiContrib.Formatting.Jsonp;
using System.Web.Http.Cors;

namespace DailyEntry.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DailyEntry",
                routeTemplate: "api/dailyEntry/{dailyFeelingId}",
                defaults: new { controller = "dailyEntry", dailyFeelingId = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Workout",
                routeTemplate: "api/dailyEntry/{dailyEntryId}/workout/{workoutId}",
                defaults: new { controller = "workout", id = RouteParameter.Optional }
            );

            //just for token implementation
            //config.Routes.MapHttpRoute(
            //    name: "Token",
            //    routeTemplate: "api/token",
            //    defaults: new { controller = "token" }
            //);

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Add support JSONP
            //var formatter = new JsonpMediaTypeFormatter(jsonFormatter, "cb");
            //config.Formatters.Insert(0, formatter);

            //todo add cache

            //Enable disable Cors
            var atr = new EnableCorsAttribute("*", "*", "*"); ;
            config.EnableCors(atr);

#if !DEBUG
      // Force HTTPS on entire API
      config.Filters.Add(new RequireHttpsAttribute());
#endif

        }
    }
}