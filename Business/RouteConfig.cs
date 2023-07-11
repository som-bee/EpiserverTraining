using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EpiserverTraining.Business
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            var routeData = new RouteValueDictionary();
            routeData.Add("Controller", "Register");
            routeData.Add("action", "Index");
            RouteTable.Routes.Add("Register", new Route("Register", routeData, new MvcRouteHandler()) { RouteExistingFiles = false });
            //   routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}",
            //    defaults: new { controller = "Register", action = "Index", id = UrlParameter.Optional }
            //);



        }
    }
}