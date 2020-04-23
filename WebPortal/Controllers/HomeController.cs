using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using ConduitPortal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebPortal.Models;

namespace WebPortal.Controllers
{
    public class HomeController : BaseController
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
            XmlReader reader = XmlReader.Create("D:\\Workshop\\GitRepo\\FjtNewsPortal\\WebPortal\\wwwroot\\assets\\tin-moi-nhat.rss");
            vmHome.NewFeeds = SyndicationFeed.Load(reader).Items.ToList();


            reader = XmlReader.Create("D:\\Workshop\\GitRepo\\FjtNewsPortal\\WebPortal\\wwwroot\\assets\\startup.rss");
            vmHome.BusinessNews = SyndicationFeed.Load(reader).Items.ToList();

            reader = XmlReader.Create("D:\\Workshop\\GitRepo\\FjtNewsPortal\\WebPortal\\wwwroot\\assets\\kinh-doanh.rss");
            vmHome.ShoppingNews = SyndicationFeed.Load(reader).Items.ToList();

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
