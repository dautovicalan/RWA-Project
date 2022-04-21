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
            routes.MapPageRoute("", "Edit/{id}", "~/EditApartment.aspx");
            routes.MapPageRoute("tagsRoute", "Tags", "~/Tags.aspx");
            routes.MapPageRoute("apartmensRoute", "Apartmens", "~/Apartmens.aspx");
        }
    }
}
