using System.Collections.Generic;
using MvcDemos.Helpers.FluentSecurity;
using MvcSiteMapProvider;

namespace MvcDemos.Helpers.MvcSiteMap
{
    public class MyCustomVisibilityProvider : SiteMapNodeVisibilityProviderBase
    {
        public override bool IsVisible(ISiteMapNode node, IDictionary<string, object> sourceMetadata)
        {
            bool isVisible = SecurityHelper.ActionIsAllowedForUser(string.Format("MvcDemos.Controllers.{0}Controller", node.Controller), node.Action);
            return isVisible;
        }
    }
}