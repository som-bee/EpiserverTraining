using EPiServer;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EpiserverTraining.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverTraining.Manager
{
    [ServiceConfiguration(Lifecycle = ServiceInstanceScope.Transient, ServiceType = typeof(IPageBuilder))]
    public class PageBuilder : IPageBuilder
    {
        private IContentRepository _contentRepository; // CRUD


        //private readonly IContentLoader _contentLoader; // fetching only Read

        //property injector : in case of static class   
        //private Injected<IContentRepository> propInjected;


        //constructor injector
        //public PageBuilder(IContentRepository contentRepository)
        //{
        //    _contentRepository = contentRepository;
        //}

        public PageBuilder()
        {

        }


        //READ
        public ArticlePage GetArticlePage(int id)
        {
            _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            //getting article page with the id
            var articlePage = _contentRepository.Get<ArticlePage>(new ContentReference(id));

            return articlePage;
        }

        //CREATE
        public ArticlePage CreateArticlePage()
        {
            //IcontentRepo using servicelocator
            //var object = ServiceLocator.Current.GetInstance<>();
            _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

            //creating new article page under the startpage (using start page id)
            var newPage = _contentRepository.GetDefault<ArticlePage>(ContentReference.StartPage);

            //assigning diff properties
            newPage.Name = "Test page";
            newPage.PageTitle = "Test";

            //saving the page
            //_contentRepository.Save(newPage,AccessLevel.NoAccess);

            //saving and publishing // NoAccess : no auth required for publishing this page
            _contentRepository.Publish(newPage, AccessLevel.NoAccess);

            return newPage;
        }



        //UPDATE
        public void UpdateArticlePage(int id, ArticlePage model)
        {
            //getting article page with the id
            var articlePage = _contentRepository.Get<ArticlePage>(new ContentReference(id));


            // DataFactoryCache.RemovePage(writablePage as ContentReference);
            if (articlePage != null && model != null)
            {

                var writablePage = (articlePage as PageData).CreateWritableClone();


                (writablePage as ArticlePage).PageTitle = model.PageTitle;
                (writablePage as ArticlePage).MainBody = model.MainBody;

                var saveAction = SaveAction.CheckIn | SaveAction.ForceNewVersion | SaveAction.Publish;


               _contentRepository.Save(writablePage, saveAction, AccessLevel.NoAccess);
            }
        }


        //DELETE
        public void DeleteArticlePage(int id)
        {
            // Get the page you want to delete
            if(new ContentReference(id) == null)
            {
                return;
            }
            var pageToDelete = _contentRepository.Get<ArticlePage>(new ContentReference(id));

            // Check if the page exists
            if (pageToDelete != null)
            {
                var writablePage = (pageToDelete as PageData).CreateWritableClone();
                _contentRepository.Delete(writablePage.ContentLink, true);

                try
                {
                    _contentRepository.Save(writablePage, SaveAction.Publish, AccessLevel.NoAccess);
                }
                catch(Exception ex)
                {

                }
                
            }
        }
    }
}