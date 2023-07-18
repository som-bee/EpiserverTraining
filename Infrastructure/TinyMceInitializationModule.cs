using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using System;
using System.Linq;

namespace EpiserverTraining.Infrastructure
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class TinyMceInitializationModule : IInitializableModule
    {
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