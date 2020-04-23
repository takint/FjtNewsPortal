using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebPortal.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public BaseController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
    }
}
