using System.Web.Mvc;
using FluentSecurity;

namespace MvcDemos.Helpers.FluentSecurity
{
    public class DefaultPolicyViolationHandler : IPolicyViolationHandler
    {
        public string ViewName = "AccessDenied";

        public ActionResult Handle(PolicyViolationException exception)
        {
            if (SecurityHelper.UserIsAuthenticated())
            {
                return new ViewResult { ViewName = ViewName };
            }
            else
            {
                System.Web.Routing.RouteValueDictionary rvd = new System.Web.Routing.RouteValueDictionary();

                if (System.Web.HttpContext.Current.Request.RawUrl != "/")
                    rvd["ReturnUrl"] = System.Web.HttpContext.Current.Request.RawUrl;

                rvd["controller"] = "Account";
                rvd["action"] = "LogOn";
                rvd["area"] = "";

                return new RedirectToRouteResult(rvd);
            }
        }
    }

}