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
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebPortal.Models;

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

        public IActionResult Index()
        {
            ReadNewFeeds();
            return View(vmHome);
        }

        private void ReadNewFeeds()
        {
            StreamReader sr = new StreamReader("./wwwroot/rss/tin-moi-nhat.rss");
            XmlReader reader = XmlReader.Create(sr);
            vmHome.NewFeeds = SyndicationFeed.Load(reader).Items.ToList();
            sr.Close();

            sr = new StreamReader("./wwwroot/rss/startup.rss");
            reader = XmlReader.Create(sr);
            vmHome.BusinessNews = SyndicationFeed.Load(reader).Items.ToList();
            sr.Close();

            sr = new StreamReader("./wwwroot/rss/kinh-doanh.rss");
            reader = XmlReader.Create(sr);
            vmHome.ShoppingNews = SyndicationFeed.Load(reader).Items.ToList();

            sr.Close();
            reader.Close();
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
