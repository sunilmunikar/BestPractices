using System;
using System.Web;
using System.Web.Mvc;

namespace MvcDemos.Core.GlobalError
{
    //http://blog.tonysneed.com/2011/10/21/global-error-handling-in-asp-net-mvc-3-with-ninject/
    public class HandleExceptionFilter : IExceptionFilter
    {
        private string _view;
        private string _master;
        private ILoggingService _loggingService;

        public HandleExceptionFilter(ILoggingService loggingService, string master, string view)
        {
            _loggingService = loggingService;
            _master = master ?? string.Empty;
            _view = view ?? string.Empty;
        }

        public virtual void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (!filterContext.IsChildAction && (!filterContext.ExceptionHandled
                && filterContext.HttpContext.IsCustomErrorEnabled))
            {
                Exception exception = filterContext.Exception;
                if ((new HttpException(null, exception).GetHttpCode() == 500))
                {
                    // Log exception
                    _loggingService.Error(exception);

                    // Show error view
                    ErrorFilterHelper.SetFilerContext(filterContext, _master, _view);
                }
            }
        }
    }
}