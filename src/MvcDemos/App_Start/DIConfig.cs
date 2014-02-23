using System;
using System.Web.Http;
using System.Web.Mvc;
using MvcDemos.MvcCore;
using MvcDemos.MvcCore.GlobalError;
using MvcDemos.DI;
using MvcDemos.DI.Unity;


[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(DIConfig), "Register")]



public class DIConfig
{
    public static void Register()
    {


        var container = CompositionRoot.Compose();

#if DependencyResolver
// ************************************************************************************** //
//  Dependency Resolver
//
//  You may use this option if you are using MVC 3 or higher and you have other code
//  that references DependencyResolver.Current.GetService() or DependencyResolver.Current.GetServices()
//
// ************************************************************************************** //

// Reconfigure MVC to use Service Location
        var dependencyResolver = new InjectableDependencyResolver(container, DependencyResolver.Current);
        DependencyResolver.SetResolver(dependencyResolver);
#else
        // ************************************************************************************** //
        //  Controller Factory
        //
        //  It is recommended to use Controller Factory unless you are getting errors due to a conflict.
        //
        // ************************************************************************************** //

        // Reconfigure MVC to use DI
        var controllerFactory = new InjectableControllerFactory(container);
        ControllerBuilder.Current.SetControllerFactory(controllerFactory);


        //http://blog.ploeh.dk/2009/12/14/WiringASP.NETMVCErrorHandlingwithCastleWindsor/
        //ControllerBuilder.Current.SetControllerFactory(new ErrorHandlingControllerFactory());
#endif

        MvcSiteMapProviderConfig.Register(container);

    }
}

