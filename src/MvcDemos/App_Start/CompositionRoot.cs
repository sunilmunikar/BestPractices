using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MvcDemos.DI;
using MvcDemos.DI.Unity;
using MvcDemos.DI.Unity.ContainerExtensions;
using Microsoft.Practices.Unity;


internal class CompositionRoot
{
    public static IDependencyInjectionContainer Compose()
    {
        var container = new UnityContainer();
        container.AddNewExtension<MvcSiteMapProviderContainerExtension>();
        container.AddNewExtension<MvcDemosContainerExtension>();

        //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        return new UnityDependencyInjectionContainer(container);
    }
}
