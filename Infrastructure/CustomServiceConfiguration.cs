using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using System;

namespace EpiserverTraining.Infrastructure
{
    [InitializableModule]
    [ModuleDependency(typeof(ServiceContainerInitialization))]
    public class CustomServiceConfiguration : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.AddTransient<EPiServer.Web.Mvc.Html.ContentAreaRenderer, EpiserverTraining.Infrastructure.ContentAreaRenderer>();
        }

        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}
