using System.Web;
using FluentSecurity;
using FluentSecurity.Policy;

namespace MvcDemos.MvcCore.Policies
{
    public class LocalOnlyPolicy : ISecurityPolicy
    {
        public PolicyResult Enforce(ISecurityContext context)
        {
            return HttpContext.Current.Request.IsLocal ?
                PolicyResult.CreateSuccessResult(this) :
                PolicyResult.CreateFailureResult(this, "Access denied!");
        }
    }
}