using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Hosting;
using Microsoft.Practices.Unity;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Builder;
using MvcSiteMapProvider.Caching;
using MvcSiteMapProvider.Security;
using MvcSiteMapProvider.Visitor;
using MvcSiteMapProvider.Web.Compilation;
using MvcSiteMapProvider.Web.Mvc;
using MvcSiteMapProvider.Web.UrlResolver;
using MvcSiteMapProvider.Xml;

namespace MvcDemos.DI.Unity.ContainerExtensions
{
    public class MvcSiteMapProviderContainerExtension
        : UnityContainerExtension
    {
        protected override void Initialize()
        {
            bool enableLocalization = true;
            string absoluteFileName = HostingEnvironment.MapPath("~/Mvc.sitemap");
            TimeSpan absoluteCacheExpiration = TimeSpan.FromMinutes(5);
            bool visibilityAffectsDescendants = true;
            bool useTitleIfDescriptionNotProvided = true;





            bool securityTrimmingEnabled = false;
            string[] includeAssembliesForScan = new string[] { "MvcDemos" };


            var currentAssembly = this.GetType().Assembly;
            var siteMapProviderAssembly = typeof(SiteMaps).Assembly;
            var allAssemblies = new Assembly[] { currentAssembly, siteMapProviderAssembly };
            var excludeTypes = new Type[] {
// Use this array to add types you wish to explicitly exclude from convention-based  
// auto-registration. By default all types that either match I[TypeName] = [TypeName] or 
// I[TypeName] = [TypeName]Adapter will be automatically wired up as long as they don't 
// have the [ExcludeFromAutoRegistrationAttribute].
//
// If you want to override a type that follows the convention, you should add the name 
// of either the implementation name or the interface that it inherits to this list and 
// add your manual registration code below. This will prevent duplicate registrations 
// of the types from occurring. 

// Example:
// typeof(SiteMap),
// typeof(SiteMapNodeVisibilityProviderStrategy)
            };
            var multipleImplementationTypes = new Type[] {
                typeof(ISiteMapNodeUrlResolver),
                typeof(ISiteMapNodeVisibilityProvider),
                typeof(IDynamicNodeProvider)
            };

// Matching type name (I[TypeName] = [TypeName]) or matching type name + suffix Adapter (I[TypeName] = [TypeName]Adapter)
// and not decorated with the [ExcludeFromAutoRegistrationAttribute].
            CommonConventions.RegisterDefaultConventions(
                (interfaceType, implementationType) => this.Container.RegisterType(interfaceType, implementationType, new ContainerControlledLifetimeManager()),
                new Assembly[] { siteMapProviderAssembly },
                allAssemblies,
                excludeTypes,
                string.Empty);

// Multiple implementations of strategy based extension points (and not decorated with [ExcludeFromAutoRegistrationAttribute]).
            CommonConventions.RegisterAllImplementationsOfInterface(
                (interfaceType, implementationType) => this.Container.RegisterType(interfaceType, implementationType, implementationType.Name, new ContainerControlledLifetimeManager()),
                multipleImplementationTypes,
                allAssemblies,
                excludeTypes,
                string.Empty);

// TODO: Find a better way to inject an array constructor

// Url Resolvers
            this.Container.RegisterType<ISiteMapNodeUrlResolverStrategy, SiteMapNodeUrlResolverStrategy>(new InjectionConstructor(
                new ResolvedArrayParameter<ISiteMapNodeUrlResolver>(this.Container.ResolveAll<ISiteMapNodeUrlResolver>().ToArray())
                ));

// Visibility Providers
            this.Container.RegisterType<ISiteMapNodeVisibilityProviderStrategy, SiteMapNodeVisibilityProviderStrategy>(new InjectionConstructor(
                new ResolvedArrayParameter<ISiteMapNodeVisibilityProvider>(this.Container.ResolveAll<ISiteMapNodeVisibilityProvider>().ToArray()),
                new InjectionParameter<string>(string.Empty)
                ));

// Dynamic Node Providers
            this.Container.RegisterType<IDynamicNodeProviderStrategy, DynamicNodeProviderStrategy>(new InjectionConstructor(
                new ResolvedArrayParameter<IDynamicNodeProvider>(this.Container.ResolveAll<IDynamicNodeProvider>().ToArray())
                ));


// Pass in the global controllerBuilder reference
            this.Container.RegisterInstance<ControllerBuilder>(ControllerBuilder.Current);

            this.Container.RegisterType<IControllerTypeResolverFactory, ControllerTypeResolverFactory>(new InjectionConstructor(
                new List<string>(),
                new ResolvedParameter<IControllerBuilder>(),
                new ResolvedParameter<IBuildManager>()));

// Configure Security

// IMPORTANT: Must give arrays of object a name in Unity in order for it to resolve them.
            this.Container.RegisterType<IAclModule, AuthorizeAttributeAclModule>("authorizeAttribute");
            this.Container.RegisterType<IAclModule, XmlRolesAclModule>("xmlRoles");
            this.Container.RegisterType<IAclModule, CompositeAclModule>(new InjectionConstructor(new ResolvedArrayParameter<IAclModule>(
                new ResolvedParameter<IAclModule>("authorizeAttribute"),
                new ResolvedParameter<IAclModule>("xmlRoles"))));






            this.Container.RegisterInstance<System.Runtime.Caching.ObjectCache>(System.Runtime.Caching.MemoryCache.Default);
            this.Container.RegisterType(typeof(ICacheProvider<>), typeof(RuntimeCacheProvider<>));
            this.Container.RegisterType<ICacheDependency, RuntimeFileCacheDependency>(
                "cacheDependency", new InjectionConstructor(absoluteFileName));

            this.Container.RegisterType<ICacheDetails, CacheDetails>("cacheDetails",
                new InjectionConstructor(absoluteCacheExpiration, TimeSpan.MinValue, new ResolvedParameter<ICacheDependency>("cacheDependency")));

// Configure the visitors
            this.Container.RegisterType<ISiteMapNodeVisitor, UrlResolvingSiteMapNodeVisitor>();

// Prepare for the sitemap node providers
            this.Container.RegisterType<IXmlSource, FileXmlSource>("file1XmlSource", new InjectionConstructor(absoluteFileName));
            this.Container.RegisterType<IReservedAttributeNameProvider, ReservedAttributeNameProvider>(new InjectionConstructor(new List<string>()));

// IMPORTANT: Must give arrays of object a name in Unity in order for it to resolve them.
// Register the sitemap node providers
            this.Container.RegisterInstance<ISiteMapNodeProvider>("xmlSiteMapNodeProvider1",
                this.Container.Resolve<XmlSiteMapNodeProviderFactory>().Create(this.Container.Resolve<IXmlSource>("file1XmlSource")), new ContainerControlledLifetimeManager());
            this.Container.RegisterInstance<ISiteMapNodeProvider>("reflectionSiteMapNodeProvider1",
                this.Container.Resolve<ReflectionSiteMapNodeProviderFactory>().Create(includeAssembliesForScan), new ContainerControlledLifetimeManager());
            this.Container.RegisterType<ISiteMapNodeProvider, CompositeSiteMapNodeProvider>(new InjectionConstructor(new ResolvedArrayParameter<ISiteMapNodeProvider>(
                new ResolvedParameter<ISiteMapNodeProvider>("xmlSiteMapNodeProvider1"),
                new ResolvedParameter<ISiteMapNodeProvider>("reflectionSiteMapNodeProvider1"))));

// Configure the builders
            this.Container.RegisterType<ISiteMapBuilder, SiteMapBuilder>();

// Configure the builder sets
            this.Container.RegisterType<ISiteMapBuilderSet, SiteMapBuilderSet>("builderSet1",
                new InjectionConstructor(
                    "default",
                    securityTrimmingEnabled,
                    enableLocalization,
                    visibilityAffectsDescendants,
                    useTitleIfDescriptionNotProvided,
                    new ResolvedParameter<ISiteMapBuilder>(),
                    new ResolvedParameter<ICacheDetails>("cacheDetails")));

            this.Container.RegisterType<ISiteMapBuilderSetStrategy, SiteMapBuilderSetStrategy>(new InjectionConstructor(
                new ResolvedArrayParameter<ISiteMapBuilderSet>(new ResolvedParameter<ISiteMapBuilderSet>("builderSet1"))));
        }
    }
}
