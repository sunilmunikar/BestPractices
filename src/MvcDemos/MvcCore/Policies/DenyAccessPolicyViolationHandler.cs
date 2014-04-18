using System.Web.Mvc;
using FluentSecurity;

namespace MvcDemos.MvcCore.Policies
{
    public class DenyAccessPolicyViolationHandler : IPolicyViolationHandler
    {
        public ActionResult Handle(PolicyViolationException exception)
        {
            return new HttpUnauthorizedResult(exception.Message);
        }
    }
}