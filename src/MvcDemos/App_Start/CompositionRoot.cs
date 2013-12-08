using Microsoft.Practices.Unity;
using MvcDemos.DI;
using MvcDemos.DI.Unity;
using MvcDemos.DI.Unity.ContainerExtensions;


internal class CompositionRoot
{
    public static IDependencyInjectionContainer Compose()
    {
        var container = new UnityContainer();
        container.AddNewExtension<MvcSiteMapProviderContainerExtension>();
        container.AddNewExtension<MvcDemosContainerExtension>();

        return new UnityDependencyInjectionContainer(container);
    }
}
