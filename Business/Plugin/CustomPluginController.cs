using EPiServer.Personalization;
using EPiServer.PlugIn;
using EPiServer.Security;
using EPiServer.Util.PlugIns;
using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;

namespace EpiserverTraining.Business.Plugin
{
    //[GuiPlugIn(Area =PlugInArea.ReportMenu, DisplayName ="Custom Report PlugIn")]
    public class CustomPluginController : Controller
    {
        // GET: CustomPlugin
        public ActionResult Index()
        {
            return View();
        }
    }

}