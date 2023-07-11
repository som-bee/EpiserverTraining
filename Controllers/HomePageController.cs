using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EpiserverTraining.Manager;
using EpiserverTraining.Models.Pages;
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
            //creating new Article page using PageBuilder
           // _pageBuilder = new PageBuilder();
           // _pageBuilder.CreateArticlePage(); 
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            return View(currentPage);
        }
    }
}