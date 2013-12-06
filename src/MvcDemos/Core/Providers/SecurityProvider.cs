using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentSecurity;

namespace MvcDemos.Core.Providers
{
    public class SecurityProvider
    {
        public static bool UserIsAuthenticated()
        {
            var currentUser = HttpContext.Current.User;
            return !string.IsNullOrEmpty(currentUser.Identity.Name);
        }

        public static IEnumerable<object> UserRoles()
        {
            var currentUser = HttpContext.Current.User;
            return string.IsNullOrEmpty(currentUser.Identity.Name) ? null : System.Web.Security.Roles.GetRolesForUser(currentUser.Identity.Name);
        }

        public static bool ActionIsAllowedForUser(string controllerNamespace, string actionName)
        {
            var configuration = SecurityConfiguration.Current;

            var policyContainer = configuration.PolicyContainers.GetContainerFor(controllerNamespace, actionName);
            if (policyContainer != null)
            {
                var context = SecurityContext.Current;
                var results = policyContainer.EnforcePolicies(context);
                return results.All(x => x.ViolationOccured == false);
            }
            return true;
        }
    }
}