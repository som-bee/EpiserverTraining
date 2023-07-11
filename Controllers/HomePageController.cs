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
    public class HomePageController : PageController<HomePage>
    {
        public ActionResult Index(HomePage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            return View(currentPage);
        }
    }
}