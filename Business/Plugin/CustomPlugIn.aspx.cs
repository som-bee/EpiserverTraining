using EPiServer;
using EPiServer.Core;
using EPiServer.Personalization;
using EPiServer.PlugIn;
using EPiServer.Security;
using EPiServer.Util.PlugIns;
using EpiserverTraining.Models.Pages;
using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;


namespace EpiserverTraining.Business.Plugin
{
    [GuiPlugIn(DisplayName = "Custom Report PlugIn ", Description = "demo plugin", Area = PlugInArea.ReportMenu, Url = "~/Business/Plugin/CustomPlugIn.aspx")]
    public partial class CustomPlugIn : System.Web.UI.Page
    {

        public static CustomPlugInViewModel Model { get; private set; }
        // OnInit method to register event handlers
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.Load += Page_Load; // Registering Page_Load as the event handler for the Load event
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var urlResolver = ServiceLocator.Current.GetInstance<IUrlResolver>();
            var _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var _contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();

 
            // Assuming StartPage is the root page of your site
            var startPage = _contentRepository.Get<IContent>(ContentReference.StartPage);
            if (startPage != null)
            {
                var children = _contentLoader.GetChildren<IContent>(startPage.ContentLink);
                List<PageLinkViewModel> subPages = new List<PageLinkViewModel>();
                foreach (var child in children)
                {
                    var childPage = _contentLoader.Get<IContent>(child.ContentLink);
                    var pageLink = new PageLinkViewModel()
                    {
                        Id = childPage.ContentLink.ID.ToString(),
                        Name = childPage.Name,
                        Url = urlResolver.GetUrl(childPage)

                    };
                    subPages.Add(pageLink);
                }
                // Set the StartPage as the model for the view
                var viewModel = new CustomPlugInViewModel
                {
                    subPages = subPages,
                };
                // Bind the view model to the view
                CustomPlugIn.Model = viewModel;
            }
        }

    }
    public class CustomPlugInViewModel
    {
        //public HomePage StartPage { get; set; }

        public List<PageLinkViewModel> subPages { get; set; }
    }

    public class PageLinkViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}