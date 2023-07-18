using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EpiserverTraining.Models.Blocks;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverTraining.Models.Pages
{
    [ContentType(DisplayName = "BlogListingPage", GUID = "3b3d5aca-63b7-4c2a-abfa-8b919aa136d5", Description = "")]
    public class BlogListingPage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "Page Title",
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


        [Display(
          Name = "Navbar",
          Description = "Navbar Menu",
          GroupName = SystemTabNames.Content,
          Order = 15)]
        public virtual NavbarMenuBlock Navbar { get; set; }
    }
}