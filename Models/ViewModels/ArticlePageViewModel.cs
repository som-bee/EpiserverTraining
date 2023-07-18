using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverTraining.Models.ViewModels
{
    public class ArticlePageViewModel : BaseViewModel
    {

        public ArticlePageViewModel(IContent content) : base(content)
        {

        }
        public virtual XhtmlString MainBody { get; set; }

        public virtual ContentReference HeaderImage { get; set; }

        public virtual ContentArea ArticlesArea { get; set; }

        public virtual List<ArticleDetailViewModel> ArticleList { get; set; }
    }
}