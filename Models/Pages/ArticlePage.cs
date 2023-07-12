using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EpiserverTraining.Models.Blocks;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverTraining.Models.Pages
{
    [ContentType(DisplayName = "ArticlePage", GUID = "dcb3ae67-5f8b-4d6d-b298-21639f6e1f21", Description = "")]
    public class ArticlePage : PageData
    {
        
            [CultureSpecific]
            [Display(
                Name = "Page Title",
                Description = "page title",
                GroupName = SystemTabNames.Content,
                Order = 1)]
            public virtual string PageTitle { get; set; }

            [CultureSpecific]
            [Display(
                Name = "Main body",
                Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                GroupName = SystemTabNames.Content,
                Order = 10)]
            public virtual XhtmlString MainBody { get; set; }


            [CultureSpecific]
            [Display(
                Name = "Articles",
                Description = "contains articles",
                GroupName = SystemTabNames.Content,
                Order = 15)]
            public virtual ContentArea ArticlesArea { get; set; }

        [Display(
         Name = "Navbar",
         Description = "Navbar Menu",
         GroupName = SystemTabNames.Content,
         Order = 15)]
        public virtual NavbarMenuBlock Navbar { get; set; }
    }
}