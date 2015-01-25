﻿using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace MvcDemos.ActionFilters
{
    public class ValidationResponseFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Called when [action executing].
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext
                        .Request
                        .CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }
    }
}