using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace rwa_project
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            routes.MapPageRoute("defaultRoute", "", "~/Default.aspx");
            routes.MapPageRoute("errorRoute", "{*.aspx}", "~/ErrorPage.aspx");
            routes.MapPageRoute("editRoute", "edit/{id}", "~/Default.aspx");
            routes.MapPageRoute("tagsRoute", "tags", "~/Tags.aspx");
            routes.MapPageRoute("apartmensRoute", "apartmens", "~/Apartmens.aspx");
            routes.RouteExistingFiles = true;
        }
    }
}
