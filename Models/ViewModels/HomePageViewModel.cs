using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverTraining.Models.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public HomePageViewModel(IContent content ): base(content)
        {
           
        }

        public virtual XhtmlString MainBody { get; set; }

         
    }
}