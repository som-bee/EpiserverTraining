using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EpiserverTraining.Models.Blocks;
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
        private readonly IContentLoader _contentLoader;

        //public ArticlePageController()
        //{

        //}
        //public ArticlePageController(IContentRepository contentRepository)
        //{
        //    _contentRepository = contentRepository;
        //}
        public ActionResult Index(ArticlePage currentPage)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

            var viewModel = new ArticlePageViewModel(currentPage)
            {
                MainBody = currentPage.MainBody,
                ArticlesArea = currentPage.ArticlesArea,
                HeaderImage = currentPage.HeaderImage,
                ArticleList = new List<ArticleDetailViewModel>()
            };
            if(currentPage.ArticlesArea != null)
            {
                foreach (var contentAreaItem in currentPage.ArticlesArea.Items)
                {
                    var articleBlock = contentRepository.Get<ArticleBlock>(contentAreaItem.ContentLink);
                    if (articleBlock != null)
                    {
                        viewModel.ArticleList.Add(
                            new ArticleDetailViewModel()
                            {
                                ArticleTitle = articleBlock.ArticleTitle,
                                ArticleImage = articleBlock.ArticleImage,
                                ArticleDescription = articleBlock.ArticleDescription
                            });
                    }
                }
            }
                

            return View(viewModel);
        }
    }
}