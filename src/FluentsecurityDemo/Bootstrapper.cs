using FluentSecurity;
using FluentsecurityDemo.Controllers;
using System.Web;

namespace FluentsecurityDemo
{
    public static class Bootstrapper
    {
        public static ISecurityConfiguration SetupFluentSecurity()
        {
            SecurityConfigurator.Configure(configuration =>
            {
                // Tell FluentSecurity where to obtain the user authentication status from
                configuration.GetAuthenticationStatusFrom(() =>
                    HttpContext.Current.User.Identity.IsAuthenticated);

                configuration.For<HomeController>().Ignore();

                // Make sure that users can still log on
                configuration.For<AccountController>(ac => ac.LogOn()).Ignore();
                configuration.For<AccountController>(ac => ac.ChangePassword()).RequireAnyRole("Administrator");
            });

            return SecurityConfiguration.Current;
        }

    }
}