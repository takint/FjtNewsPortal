using ConduitPortal.Services;
using ConduitPortal.ViewModels;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using WebPortal.Models;

namespace WebPortal.Controllers
{
    public class ArticleController : BaseController<ArticleController>
    {
        private readonly IArticleService _articleService;
        private ArticlePageViewModel vmArticle;

        public ArticleController(ILogger<ArticleController> logger, IArticleService articleService)
            : base(logger)
        {
            _articleService = articleService;
            vmArticle = new ArticlePageViewModel();
            vmArticle.TopBannerImage = "/assets/top-banner-adv.png";
            vmArticle.SiteLogoImage = "/assets/portal-top-logo.png";
            vmArticle.FooterLogoImage = "/assets/portal-foot-logo.png";
        }


        public async Task<IActionResult> Index(string articleSlug)
        {
            //vmArticle.ArticleVM = await _articleService.GetByIdAsync<ArticleViewModel>(4);
            GetData(articleSlug);
            return View(vmArticle);
        }

        private void GetData(string webUrl)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDoc = web.Load(webUrl);
            var article = htmlDoc.DocumentNode.Descendants("article")
                                           .First(doc => doc.HasClass("fck_detail"));
            var title = htmlDoc.DocumentNode.Descendants("h1")
                                           .First(doc => doc.HasClass("title-detail"));
            //tam-trang-khi-yeu-kiet-tac-tu-nhung-manh-ghep
            vmArticle.ArticleVM.Title = title.InnerText;
            vmArticle.ArticleVM.Body = article.OuterHtml;
        }

        public IActionResult CultureConnect()
        {
            return View(vmArticle);
        }
    }
}