using System.Collections.Generic;
using MvcSiteMapProvider;

namespace MvcDemos.MvcCore.Providers
{
    public class MyCustomVisibilityProvider : SiteMapNodeVisibilityProviderBase
    {
        public override bool IsVisible(ISiteMapNode node, IDictionary<string, object> sourceMetadata)
        {
            bool isVisible = SecurityProvider.ActionIsAllowedForUser(string.Format("MvcDemos.Controllers.{0}Controller", node.Controller), node.Action);
            return isVisible;
        }
    }
}