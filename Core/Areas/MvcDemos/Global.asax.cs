using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
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
            Database.SetInitializer(new MvcDemos.Models.SampleData());

            AreaRegistration.RegisterAllAreas();

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
        }
    }
}