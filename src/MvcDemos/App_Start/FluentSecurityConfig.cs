using System.Web;
using Common;
using FluentSecurity;
using MvcDemos.Areas.SecurityGuard.Controllers;
using MvcDemos.Controllers;

namespace MvcDemos
{
    public static class FluentSecurityConfig
    {
        public static ISecurityConfiguration SetupFluentSecurity()
        {
            SecurityConfigurator.Configure(configuration =>
            {
                // Tell FluentSecurity where to obtain the user authentication status from
                configuration.GetAuthenticationStatusFrom(() =>
                    HttpContext.Current.User.Identity.IsAuthenticated);

                //configuration.ForAllControllers().DenyAnonymousAccess();
                configuration.ForAllControllers().Ignore();
                configuration.Advanced.IgnoreMissingConfiguration();

                configuration.For<HomeController>(x => x.About()).DenyAnonymousAccess();
                configuration.For<HomeController>(x => x.AnonymouslyVisible()).Ignore();

                configuration.For<SGAccountController>(x => x.Index()).Ignore();
                configuration.For<SGAccountController>(x => x.Login()).Ignore();


                ////first deny access to all users except Administrators
                configuration.ForAllControllersInNamespaceContainingType<DashboardController>()
                    .DenyAuthenticatedAccess()
                    .RequireAnyRole(RoleName.SecurityGuard);

                // Make sure that users can still log on
                //configuration.For<AccountController>(ac => ac.LogOn()).Ignore();
                //configuration.For<AccountController>(ac => ac.ChangePassword()).RequireAnyRole("Administrator");
                //configuration.For<AccountController>(ac => ac.Register()).Ignore();
                //configuration.For<AccountController>(ac => ac.Register(null)).Ignore();
            });

            return SecurityConfiguration.Current;
        }
    }
}