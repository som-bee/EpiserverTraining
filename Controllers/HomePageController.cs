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

namespace EpiserverTraining.Controllers
{
    public class HomePageController : PageController<HomePage>
    {
        private Injected<IPageBuilder>  _pageBuilder;



        //public HomePageController(IPageBuilder pageBuilder)
        //{
        //    _pageBuilder = pageBuilder;
        //}

        public ActionResult Index(HomePage currentPage)
        {

            //performCRUD();


            var viewModel = new HomePageViewModel(currentPage)
            {
                MainBody = currentPage.MainBody
            };
            

            return View(viewModel);
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