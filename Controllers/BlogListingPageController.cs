using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using EpiserverTraining.Models.Pages;
using EpiserverTraining.Models.ViewModels;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(blogPage.MainBody.ToString());

                // Get all text nodes from the HTML document
                var textNodes = htmlDoc.DocumentNode.SelectNodes("//text()");

                // Concatenate the text from each node to get the plain text
                string plainText = string.Join(" ", textNodes.Select(node => node.InnerText.Trim()));

                // Decode any HTML entities (e.g., &nbsp;, &lt;, etc.)
                plainText = HttpUtility.HtmlDecode(plainText);



                var blogDetailViewModel = new BlogDetailViewModel()
                {
                    HeaderImage = blogPage.HeaderImage,
                    BlogPageTitle= blogPage.PageTitle,
                    Url = urlResolver.GetUrl(blogPage),
                    BlogPageContentText = plainText.Substring(0, Math.Min(plainText.Length, 200))
            };
                viewModel.blogPages.Add(blogDetailViewModel);
            }
            



            return View(viewModel);
        }
    }
}