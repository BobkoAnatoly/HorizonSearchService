using Microsoft.AspNetCore.Mvc;
using Persistence.Models;

namespace Web.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index(RepositoryModel model)
        {

            return View();
        }
    }
}
