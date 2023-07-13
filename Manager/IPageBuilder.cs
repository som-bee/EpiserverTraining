using EPiServer.Core;
using EpiserverTraining.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiserverTraining.Manager
{
    public interface IPageBuilder
    {
        ArticlePage CreateArticlePage();

        ArticlePage GetArticlePage(int id);

        void UpdateArticlePage(int id, ArticlePage model);

        void DeleteArticlePage(int id);
    }
}
