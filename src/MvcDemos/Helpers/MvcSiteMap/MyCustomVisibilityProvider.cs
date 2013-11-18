using System.Collections.Generic;
using System.Web;
using MvcDemos.Helpers.FluentSecurity;
using MvcSiteMapProvider;

namespace MvcDemos.Helpers.MvcSiteMap
{
    public class MyCustomVisibilityProvider : SiteMapNodeVisibilityProviderBase
    {
        //public bool IsVisible(ISiteMapNode node, HttpContext context, IDictionary<string, object> sourceMetadata)
        //{
        //    // Convert to MvcSiteMapNode
        //    //var mvcNode = node as MvcSiteMapNode;
        //    if (node == null)
        //    {
        //        return true;
        //    }

        //    //First check the visibility based on user roles
        //    //string controllerNamespace = (new DefaultControllerTypeResolver()).ResolveControllerType(node.Area, node.Controller).FullName;
        //    bool isVisible = SecurityHelper.ActionIsAllowedForUser(node.Controller, node.Action);
        //    if (!isVisible)
        //        return false;

        //    //Process Other Visibility Rules
        //    //...

        //    return true;
        //}

        public override bool IsVisible(ISiteMapNode node, IDictionary<string, object> sourceMetadata)
        {

            //bool isVisible = SecurityHelper.ActionIsAllowedForUser(node.Controller, node.Action);
            //if (!isVisible)
            //    return false;

            return false;
        }


    }


}