using Microsoft.AspNetCore.Mvc;
using Application.Models;
using System.Web;

namespace Web.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Index([FromQuery]RepositorySearchModel model)
        {
            

            return View();
        }

    }
}
