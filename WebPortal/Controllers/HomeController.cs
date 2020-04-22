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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService)
        {
            _logger = logger;
            _articleService = articleService;
        }

        public async Task<IActionResult> Index()
        {
            HomePageViewModel vm = new HomePageViewModel();
            vm.NewFeeds = ReadNewFeeds();

            return View(vm);
        }

        private List<SyndicationItem> ReadNewFeeds()
        {
            XmlReader reader = XmlReader.Create("D:\\Workshop\\GitRepo\\FjtNewsPortal\\WebPortal\\wwwroot\\assets\\tin-moi-nhat.rss");
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            return feed.Items.ToList();
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
