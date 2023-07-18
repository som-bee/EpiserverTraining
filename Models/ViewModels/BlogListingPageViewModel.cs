using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverTraining.Models.ViewModels
{
    public class BlogListingPageViewModel : BaseViewModel
    {

        public BlogListingPageViewModel(IContent content) : base(content)
        {

        }
        public virtual XhtmlString MainBody { get; set; }

        public virtual List<BlogDetailViewModel> blogPages { get; set; }


    }
}