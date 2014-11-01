using MvcDemos.ExceptionHandling;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace MvcDemos
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration httpConfiguration)
        {
            // Web API routes
            httpConfiguration.MapHttpAttributeRoutes();

            httpConfiguration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            httpConfiguration.Services.Replace(typeof(IExceptionHandler), new ApiExceptionHandler());
        }
    }
}
