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
            await GetVnExpData($"https://vnexpress.net{articleSlug}");
            return View(vmArticle);
        }

        private async Task GetVnExpData(string webUrl)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDoc = await web.LoadFromWebAsync(webUrl);
            var article = htmlDoc.DocumentNode.Descendants("article")
                                           .First(doc => doc.HasClass("fck_detail"));
            var title = htmlDoc.DocumentNode.Descendants("h1")
                                           .First(doc => doc.HasClass("title-detail"));

            vmArticle.ArticleVM.Title = title.InnerText;
            vmArticle.ArticleVM.Body = article.OuterHtml;
        }

        public IActionResult CultureConnect()
        {
            return View(vmArticle);
        }
    }
}