using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EpiserverTraining.Models.Blocks
{
    [ContentType(DisplayName = "Navbar Menu Block", GUID = "a60b4ff7-4b60-4ef6-ad9c-f9c0a876966e", Description = "")]
    public class NavbarMenuBlock : BlockData
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Name",
                    Description = "Name field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual string Name { get; set; }
         */
        [Display(Name ="Main Navigation")]
        public virtual IList<ContentReference> MainNavigation { get; set; }
    }
}