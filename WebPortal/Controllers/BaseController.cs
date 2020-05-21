using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebPortal.Controllers
{
    public class BaseController<T> : Controller
    {
        private readonly ILogger<T> _logger;
        public BaseController(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}
