using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WebApiDemos.ExceptionHandling;

namespace WebApiDemos
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration httpConfiguration)
        {
            // Web API configuration and services

            // Web API routes
            httpConfiguration.MapHttpAttributeRoutes();

            httpConfiguration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            httpConfiguration.Services.Add(typeof(IExceptionLogger), new NLogExceptionLogger());
            httpConfiguration.Services.Add(typeof(IExceptionLogger), new ElmahExceptionLogger());
            httpConfiguration.Services.Replace(typeof(IExceptionHandler), new ApiExceptionHandler());

            httpConfiguration.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
        }
    }
}