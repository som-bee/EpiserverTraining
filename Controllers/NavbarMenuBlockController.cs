using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using EpiserverTraining.Models.Blocks;
using EpiserverTraining.Models.Pages;
using EpiserverTraining.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpiserverTraining.Controllers
{
    public class NavbarMenuBlockController : BlockController<NavbarMenuBlock>
    {
        public override ActionResult Index(NavbarMenuBlock currentBlock)
        {
            var contentLoader =  ServiceLocator.Current.GetInstance<IContentLoader>();
            var urlResolver = ServiceLocator.Current.GetInstance<IUrlResolver>();
            NavbarMenuViewModel navViewModel = new NavbarMenuViewModel() {
                MainNavigation = new List<Navigation>()
            };
            if(currentBlock.MainNavigation != null)
            {
                foreach (var item in currentBlock.MainNavigation)
                {
                    var content = contentLoader.Get<IContent>(item);
                    var nav = new Navigation()
                    {
                        Id = content.ContentLink.ID.ToString(),
                        Name = content.Name,
                        Url = urlResolver.GetUrl(content),

                    };

                    if (!(content is HomePage))
                    {
                        var children = contentLoader.GetChildren<IContent>(item);
                        if (children != null)
                        {
                            nav.SubNavigation = new List<Navigation>();
                            foreach (var child in children)
                            {
                                content = contentLoader.Get<IContent>(child.ContentLink);
                                nav.SubNavigation.Add(new Navigation()
                                {
                                    Id = content.ContentLink.ID.ToString(),
                                    Name = content.Name,
                                    Url = urlResolver.GetUrl(content)
                                });
                            }

                        }
                    }


                    navViewModel.MainNavigation.Add(nav);
                }
            }
           
            return PartialView(navViewModel);
        }
    }
}
