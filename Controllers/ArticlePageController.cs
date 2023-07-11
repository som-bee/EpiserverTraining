using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EpiserverTraining.Models.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EpiserverTraining.Controllers
{
    public class ArticlePageController : PageController<ArticlePage>
    {
        private readonly IContentRepository _contentRepository;

        public ArticlePageController()
        {

        }
        public ArticlePageController(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }
        public ActionResult Index(ArticlePage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            ViewBag.articile = currentPage.ArticlesArea;
            return View(currentPage);
        }
    }
}