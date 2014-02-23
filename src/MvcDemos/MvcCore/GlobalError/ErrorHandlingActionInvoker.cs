using System;
using System.Web.Mvc;

namespace MvcDemos.MvcCore.GlobalError
{
    //http://blog.ploeh.dk/2009/12/01/GlobalErrorHandlinginASP.NETMVC/
    public class ErrorHandlingActionInvoker :
        ControllerActionInvoker
    {
        private readonly IExceptionFilter _filter;

        public ErrorHandlingActionInvoker(IExceptionFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter");
            }
            _filter = filter;
        }

        protected override FilterInfo GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filterInfo = base.GetFilters(controllerContext, actionDescriptor);
            filterInfo.ExceptionFilters.Add(this._filter);

            return filterInfo;
        }
    }
}