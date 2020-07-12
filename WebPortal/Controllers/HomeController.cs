using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using ConduitPortal.Services;
using ConduitPortal.ViewModels;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebPortal.Models;
using WebPortal.Utils;

namespace WebPortal.Controllers
{
    public class HomeController : BaseController<HomeController>
    {

        private readonly IArticleService _articleService;
        private HomePageViewModel vmHome;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService)
            : base(logger)
        {
            _articleService = articleService;
            vmHome = new HomePageViewModel();
            vmHome.TopBannerImage = "/assets/top-banner-adv.png";
            vmHome.SiteLogoImage = "/assets/portal-top-logo.png";
            vmHome.FooterLogoImage = "/assets/portal-foot-logo.png";
        }

        public async Task<IActionResult> Index()
        {
            await ReadNewFeeds();
            return View(vmHome);
        }

        private async Task ReadNewFeeds()
        {
            vmHome.NewFeeds = await PortalUtil.LoadNewsFromRss();
            vmHome.BusinessNews = await PortalUtil.LoadNewsFromRss("./wwwroot/rss/kinh-doanh.rss");
            vmHome.ShoppingNews = await PortalUtil.LoadNewsFromRss("./wwwroot/rss/startup.rss");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
