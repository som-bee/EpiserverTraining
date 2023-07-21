using EPiServer.Cms.TinyMce.Core;
using EPiServer.ServiceLocation;
using EpiserverTraining.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverTraining.Business.Extensions
{
    public static class ServiceConfigurationContextExtensions
    {
        public static void ConfigureTinyMceControl(this ServiceConfigurationContext context)
        {
            context.Services.Configure<TinyMceConfiguration>(config =>
            {
                config.Default()
                    .AddPlugin("advlist autolink lists link image charmap print preview anchor searchreplace visualblocks code fullscreen insertdatetime media table paste code help wordcount  textcolor colorpicker")
                    .Toolbar("undo redo | formatselect | bold italic underline strikethrough | alignleft aligncenter alignright alignjustify | outdent indent | numlist bullist | link image media | table | forecolor backcolor | removeformat code")
                    .AddSetting("image_caption", true)
                    .AddSetting("image_advtab", true);
                config.For<ArticlePage>(x=>x.MainBody)
                    .AddPlugin("advlist autolink lists link image charmap print preview anchor searchreplace visualblocks  fullscreen insertdatetime media table paste help wordcount  textcolor colorpicker")
                    .Toolbar("undo redo | formatselect | bold italic underline strikethrough | alignleft aligncenter alignright alignjustify | outdent indent | numlist bullist | link image media | table | forecolor backcolor | removeformat ")
                    .AddSetting("image_caption", true)
                    .AddSetting("image_advtab", true);
            } 
             );
        }
    }
}