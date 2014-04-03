using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcDemos.Samples.Validation
{
    public class FluentValidationExceptionHandlingActionInvoker :
        ControllerActionInvoker
    {
        protected override ActionResult InvokeActionMethod(
            ControllerContext controllerContext,
            ActionDescriptor actionDescriptor,
            IDictionary<string, object> parameters)
        {
            try
            {
                //invoke the action method as usual
                return base.InvokeActionMethod(controllerContext, actionDescriptor, parameters);
            }
            catch (FluentValidation.ValidationException e)
            {
                //if some validation exception occurred (in my case in the business layer) 
                //mark the modelstate as not valid  and run the same action method again
                //so that it can return the proper view with validation errors. 

                foreach (var error in e.Errors)
                    controllerContext.Controller.ViewData.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

                return base.InvokeActionMethod(controllerContext, actionDescriptor, parameters);
            }
        }
    }
}