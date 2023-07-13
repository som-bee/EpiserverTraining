using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EpiserverTraining.Models.Blocks;
using EpiserverTraining.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverTraining.Models.ViewModels
{
    public class BaseViewModel
    {
        

        public virtual string PageTitle { get; set; }
        public NavbarMenuBlock Navbar { get; set; }

        public BaseViewModel(IContent content)
        {
            
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var startPage = content is HomePage ? content as HomePage : contentLoader.Get<HomePage>(ContentReference.StartPage);
            Navbar =  startPage.Navbar;
            PageTitle = content.Name;
        }
    }
}