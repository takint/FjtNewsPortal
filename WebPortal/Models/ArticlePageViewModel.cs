using ConduitPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPortal.Models
{
    public class ArticlePageViewModel : LayoutViewModel
    {
        public ArticleViewModel ArticleVM { get; set; }

        public List<ArticleViewModel> RelatedArticle { get; set; }

        public ArticlePageViewModel()
        {
            ArticleVM = new ArticleViewModel();
            RelatedArticle = new List<ArticleViewModel>();
        }
    }
}
