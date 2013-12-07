using System.Web.Mvc;

namespace MvcDemos.Core.GlobalError
{
    //http://blog.tonysneed.com/2011/10/21/global-error-handling-in-asp-net-mvc-3-with-ninject/
    internal static class ErrorFilterHelper
    {
        public static void SetFilerContext(ExceptionContext filterContext, string master, string view)
        {
            // Show error view
            string controllerName = (string)filterContext.RouteData.Values["controller"];
            string actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            var result = new ViewResult
                             {
                                 ViewName = view,
                                 MasterName = master,
                                 ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                                 TempData = filterContext.Controller.TempData
                             };
            filterContext.Result = result;
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 200;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}