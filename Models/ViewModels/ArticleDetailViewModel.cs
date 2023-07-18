using EPiServer.Core;

namespace EpiserverTraining.Models.ViewModels
{
    public class ArticleDetailViewModel
    {
        public virtual ContentReference ArticleImage { get; set; }
        public virtual string ArticleTitle { get; set; }
        public virtual string ArticleDescription { get; set; }

        public string Url { get; set; } 
    }
}