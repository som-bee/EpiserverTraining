using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EpiserverTraining.Models.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpiserverTraining.Controllers
{
    public class ArticleBlockController : BlockController<ArticleBlock>
    {
        public override ActionResult Index(ArticleBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }
}
