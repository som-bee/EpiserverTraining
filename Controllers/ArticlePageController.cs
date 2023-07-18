using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EpiserverTraining.Models.Pages;
using EpiserverTraining.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EpiserverTraining.Controllers
{
    public class ArticlePageController : PageController<ArticlePage>
    {
        private readonly IContentRepository _contentRepository;

        //public ArticlePageController()
        //{

        //}
        //public ArticlePageController(IContentRepository contentRepository)
        //{
        //    _contentRepository = contentRepository;
        //}
        public ActionResult Index(ArticlePage currentPage)
        {
            var viewModel = new ArticlePageViewModel(currentPage)
            {
                MainBody = currentPage.MainBody,
                ArticlesArea = currentPage.ArticlesArea,
                HeaderImage = currentPage.HeaderImage
            };




            return View(viewModel);
        }
    }
}