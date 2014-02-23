using System.Web.Mvc;
using FluentSecurity;
using MvcDemos.MvcCore.Providers;

namespace MvcDemos.MvcCore.Policies
{
    public class DefaultPolicyViolationHandler : IPolicyViolationHandler
    {
        public string ViewName = "AccessDenied";

        public ActionResult Handle(PolicyViolationException exception)
        {
            if (SecurityProvider.UserIsAuthenticated())
            {
                return new ViewResult { ViewName = ViewName };
            }
            else
            {
                var rvd = new System.Web.Routing.RouteValueDictionary();

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