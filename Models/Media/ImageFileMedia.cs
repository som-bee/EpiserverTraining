using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiserverTraining.Models.Media
{
    [ContentType(DisplayName = "ImageFileMedia", GUID = "bb514c57-fa01-485d-b267-9eb2b0dfac34", Description = "")]
    [MediaDescriptor(ExtensionString = "png,jpg,jpeg")]
    public class ImageFileMedia : MediaData
    {
        /*
                [CultureSpecific]
                [Editable(true)]
                [Display(
                    Name = "Description",
                    Description = "Description field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual string Description { get; set; }
         */
    }
}