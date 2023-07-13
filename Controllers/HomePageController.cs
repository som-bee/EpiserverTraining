using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EpiserverTraining.Manager;
using EpiserverTraining.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EpiserverTraining.Controllers
{
    public class HomePageController : PageController<HomePage>
    {
        private IPageBuilder _pageBuilder;

      

        //public HomePageController(IPageBuilder pageBuilder)
        //{
        //    _pageBuilder = pageBuilder;
        //}

        public ActionResult Index(HomePage currentPage)
        {

            performCRUD();

            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            return View(currentPage);
        }

        private void performCRUD()
        {
            //creating new Article page using PageBuilder
            _pageBuilder = new PageBuilder();

            //CREATE
            //var newPage = _pageBuilder.CreateArticlePage(); 



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