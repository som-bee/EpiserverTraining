using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServer.ServiceLocation;
using EpiserverTraining.Manager;
using EpiserverTraining.Models.Pages;
using EpiserverTraining.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Filters;

namespace EpiserverTraining.Controllers
{
    public class HomePageController : PageController<HomePage>
    {
        private Injected<IPageBuilder>  _pageBuilder;

        private readonly IClient _searchClient;



        public HomePageController(IClient searchClient)
        {
            _searchClient = searchClient;
        }

        public ActionResult Index(HomePage currentPage)
        {

            //performCRUD();

            //EpiFindTest();


            var viewModel = new HomePageViewModel(currentPage)
            {
                MainBody = currentPage.MainBody
            };
            

            return View(viewModel);
        }

        private void EpiFindTest()
        {

            //###################### FIND
            var test1 = _searchClient.Search<ArticlePage>()
                //.Filter(x => x.Name.MatchCaseInsensitive("Tech Blogs"))
                .GetContentResult();

            //#########################

            	var test = _searchClient.UnifiedSearchFor("Blog").GetResult();

            // 2000 of articlePage which as name equal to start, 1K
            //var test1 = _searchClient.Search<ArticlePage>()
            //	.For("Alloy")
            //   // .Filter(x => x.Name.MatchCaseInsensitive("Alloy Saves Bears"))
            //   	.TermsFacetFor(x => x.Name)
            //	.GetContentResult();


            //###################### SEARCH
            var criterias = new PropertyCriteriaCollection
             {
             	//new PropertyCriteria()
             	//{
             	//	Name = "PageName",
             	//	Type = PropertyDataType.String,
             	//	Condition = EPiServer.Filters.CompareCondition.StartsWith,
             	//	Value = "Alloy"
             	//},
             	new PropertyCriteria()
                 {
                     Condition = CompareCondition.Equal,
                     Name = "PageTypeName",
                     Type = PropertyDataType.PageType,
                     Value = "ArticlePage",
                     Required = true
                 }
             };

            var repository = ServiceLocator.Current.GetInstance<IPageCriteriaQueryService>();
            var pages = repository.FindPagesWithCriteria(
                 PageReference.StartPage,
                 criterias);

        }

        private void performCRUD()
        {
            //creating new Article page using PageBuilder
            //_pageBuilder = new PageBuilder();

            //CREATE
            var newPage = _pageBuilder.Service.CreateArticlePage(); 



            //READ
            // ArticlePage articlePage = _pageBuilder.GetArticlePage(6);



            //UPDATE
            //ArticlePage model = new ArticlePage()
            //{

            //    PageTitle = "Updated Title 3",
            //    MainBody = new XhtmlString("<p>This is the new content.</p>")
            //};
            //_pageBuilder.UpdateArticlePage(12, model);


            //DELETE
            //_pageBuilder.DeleteArticlePage(newPage.ContentLink.ID);
            //_pageBuilder.DeleteArticlePage(21);
        }
    }
}