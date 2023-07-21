using EPiServer.ServiceLocation;
using EpiserverTraining.Business;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace EpiserverTraining
{
    public class EPiServerApplication : EPiServer.Global
    {
        protected override void RegisterRoutes(RouteCollection routes)
        {
            base.RegisterRoutes(routes);
            RouteConfig.RegisterRoutes(routes);

        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            // Register the custom ContentAreaRenderer
            // ServiceConfigurationContext context = ServiceConfigurationContext.Current;
            //context.Services.AddTransient<EPiServer.Web.Mvc.Html.ContentAreaRenderer, EpiserverTraining.Infrastructure.ContentAreaRenderer>();

            //DependencyResolver.Current.GetService<EPiServer.Web.Mvc.Html.ContentAreaRenderer, EpiserverTraining.Infrastructure.ContentAreaRenderer>();

            //Tip: Want to call the EPiServer API on startup? Add an initialization module instead (Add -> New Item.. -> EPiServer -> Initialization Module)
        }
    }
}