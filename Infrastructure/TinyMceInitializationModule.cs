﻿using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EpiserverTraining.Infrastructure
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class TinyMceInitializationModule : IInitializableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(context.StructureMap()));
            context.Services.AddTransient<EPiServer.Web.Mvc.Html.ContentAreaRenderer, EpiserverTraining.Infrastructure.ContentAreaRenderer>();
            //context.ConfigureTinymceControl();
            
        }
        public void Initialize(InitializationEngine context)
        {
            //Add initialization logic, this method is called once after CMS has been initialized
             
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic

        }
    }
}