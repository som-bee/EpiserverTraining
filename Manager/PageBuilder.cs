using EPiServer;
using EPiServer.Core;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EpiserverTraining.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverTraining.Manager
{
    public class PageBuilder : IPageBuilder
    {
        private readonly IContentRepository _contentRepository; // CRUD


        //private readonly IContentLoader _contentLoader; // fetching only Read

        //property injector : in case of static class   
        //private Injected<IContentRepository> propInjected;


        //constructor injector
        public PageBuilder(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public void CreateArticlePage()
        {
            //IcontentRepo using servicelocator
           //var object = ServiceLocator.Current.GetInstance<>();

            //getting article page with the id 6
            var articlePage = _contentRepository.Get<ArticlePage>(new ContentReference("6"));

            //creating new article page under the startpage (using start page id)
            var newPage = _contentRepository.GetDefault<ArticlePage>(ContentReference.StartPage);
            
            //assigning diff properties
            newPage.Name = "Test page";
            newPage.PageTitle = "Test";

            //saving the page
            //_contentRepository.Save(newPage,AccessLevel.NoAccess);

            //saving and publishing // NoAccess : no auth required for publishing this page
            _contentRepository.Publish(newPage, AccessLevel.NoAccess);
        }
    }
}