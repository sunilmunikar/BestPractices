using System.Web.Mvc;

namespace MvcDemos.Core.GlobalError
{
    public class ErrorHandlingControllerFactory :
        DefaultControllerFactory
    {
        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            var controller = base.CreateController(requestContext, controllerName);
            var c = controller as Controller;

            if (c != null)
            {
                c.ActionInvoker = new ErrorHandlingActionInvoker(new HandleErrorAttribute());
            }

            return controller;
        }
    }
}