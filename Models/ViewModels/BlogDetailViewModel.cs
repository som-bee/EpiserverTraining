using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverTraining.Models.ViewModels
{
    public class BlogDetailViewModel
    {
        public virtual ContentReference HeaderImage { get; set; }

        public virtual string BlogPageTitle { get; set; }

        public virtual string BlogPageContentText { get; set; }

        public string Url { get; set; }
    }
}