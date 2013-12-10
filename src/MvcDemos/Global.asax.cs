using System;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Core;
using FluentValidation.Mvc;
using FluentValidation.Validators;
using MvcDemos.Validators;

namespace MvcDemos
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new SampleData());

            AreaRegistration.RegisterAllAreas();

            FluentSecurityConfig.SetupFluentSecurity();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //FluentValidationModelValidatorProvider.Configure();
            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.Add(typeof(NotEqualValidator), (metadata, context, description, validator) => new NotEqualPropertyValidator(metadata, context, description, validator));
                provider.Add(typeof(LessThanOrEqualValidator), (metadata, context, rule, validator) => new LessThanOrEqualToFluentValidationPropertyValidator(metadata, context, rule, validator));
            });

            // NOTE: Remove the following lines if you need .aspx support
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            MvcHandler.DisableMvcResponseHeader = true;
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
        }
    }
}