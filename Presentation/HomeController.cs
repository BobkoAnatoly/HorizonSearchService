using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Web.Mvc;

namespace Presentation
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Search()
        {
            return View();
        }
    }
}
