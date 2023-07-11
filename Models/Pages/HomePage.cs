using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverTraining.Models.Pages
{
    [ContentType(DisplayName = "HomePage", GUID = "bc20ea29-0f96-460e-bef2-ef3ec395e727", Description = "")]
    public class HomePage : PageData
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

    }
}