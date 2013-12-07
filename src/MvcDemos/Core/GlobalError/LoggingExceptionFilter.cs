using System;
using System.Web.Mvc;

namespace MvcDemos.Core.GlobalError
{
    public class LoggingExceptionFilter : IExceptionFilter
    {
        //http://blog.tonysneed.com/2011/10/21/global-error-handling-in-asp-net-mvc-3-with-ninject/
        //http://blog.ploeh.dk/2009/12/07/LoggingExceptionFilter/

        private readonly IExceptionFilter _filter;
        private readonly ILoggingService _logWriter;

        public LoggingExceptionFilter(IExceptionFilter filter,
                                      ILoggingService logWriter)
        {
            if (filter == null)
                throw new ArgumentNullException("filter");
            if (logWriter == null)
                throw new ArgumentNullException("logWriter");

            _filter = filter;
            _logWriter = logWriter;
        }

        #region IExceptionFilter Members

        public void OnException(ExceptionContext filterContext)
        {
            _logWriter.Error(filterContext.Exception);
            _filter.OnException(filterContext);
        }

        #endregion
    }
}