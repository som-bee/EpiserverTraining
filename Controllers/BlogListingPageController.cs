using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using EpiserverTraining.Models.Pages;
using EpiserverTraining.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EpiserverTraining.Controllers
{
    public class BlogListingPageController : PageController<BlogListingPage>
    {
        public ActionResult Index(BlogListingPage currentPage)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var urlResolver = ServiceLocator.Current.GetInstance<IUrlResolver>();

            var viewModel = new BlogListingPageViewModel(currentPage)
            {
                MainBody = currentPage.MainBody,
                blogPages = new List<BlogDetailViewModel>()
            };

            var blogPages = contentLoader.GetChildren<ArticlePage>(currentPage.ContentLink);

            foreach(var blogPage in blogPages)
            {
                var blogDetailViewModel = new BlogDetailViewModel()
                {
                    HeaderImage = blogPage.HeaderImage,
                    BlogPageTitle= blogPage.PageTitle,
                    Url = urlResolver.GetUrl(blogPage)
                };
                viewModel.blogPages.Add(blogDetailViewModel);
            }
            



            return View(viewModel);
        }
    }
}