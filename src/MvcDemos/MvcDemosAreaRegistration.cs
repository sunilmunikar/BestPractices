using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CleaningUpController
{
    public class MvcDemosAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "MvcDemos"; }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "mvcDemos_default",
                "MvcDemos/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcDemos.Controllers" }
            );
        }
    }
}