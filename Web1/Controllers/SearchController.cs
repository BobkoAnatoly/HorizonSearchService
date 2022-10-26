using Microsoft.AspNetCore.Mvc;
using Persistence.Models;
using System.Web;

namespace Web.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Index(SearchModel model)
        {
            

            //var redirectURL = string.Empty;
            //var url = Request.QueryString.Value;
            //string[] urlParts = url.ToLower().Split('?');
            //var querystrings = HttpUtility.ParseQueryString(urlParts[1]);

            //querystrings.Remove("s");

            //if (querystrings.Count > 0)
            //{
            //    redirectURL = urlParts[0] + "?"
            //      + string.Join("&", querystrings.AllKeys.Select(c => c.ToString() + "=" + querystrings[c.ToString()]));
            //}
            //else
            //{
            //    redirectURL = urlParts[0];
            //}
            //Response.Redirect(redirectURL);
            return View();
        }

    }
}
