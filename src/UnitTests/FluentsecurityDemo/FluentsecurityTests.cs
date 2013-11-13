using FluentSecurity;
using FluentSecurity.Policy;
using FluentSecurity.TestHelper;
using FluentsecurityDemo;
using FluentsecurityDemo.Controllers;
using System.Linq;
using Xunit;

namespace UnitTests.FluentsecurityDemo
{
    public class FluentsecurityTests
    {
        [Fact]
        public void FactMethodName()
        {
            Bootstrapper.SetupFluentSecurity();

            var results = SecurityConfiguration.Current.Verify(expectations =>
                                                                   {
                                                                       expectations.Expect<HomeController>().Has<IgnorePolicy>();
                                                                   });
            Assert.True(results.Valid());
        }

        [Fact]
        public void AccountController_ChangePasswordRequiresAnyRole()
        {
            Bootstrapper.SetupFluentSecurity();

            var results = SecurityConfiguration.Current.Verify(expectations =>
            {
                expectations.Expect<AccountController>(x => x.ChangePassword())
                    .Has<RequireAnyRolePolicy>(
                    p => p.RolesRequired.Contains("Administrator") &&
                    p.RolesRequired.Count() == 1);

            });

            Assert.True(results.Valid());
        }
    }
}
