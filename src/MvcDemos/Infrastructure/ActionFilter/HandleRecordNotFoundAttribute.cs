using System;
using System.Web.Mvc;

namespace MvcDemos.Infrastructure
{
    public class HandleRecordNotFoundAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;

            if (viewResult.ViewData.Model == null)
            {
                filterContext.Result = new ResourceNotFoundResult();
                filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
            }
        }
    }
}