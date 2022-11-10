using Microsoft.AspNetCore.Mvc;
using Application.Models;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Application.Handlers;

namespace Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IMapper _mapper;
        public SearchController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index([FromQuery]RepositorySearchModel model)
        {
            var request = _mapper.Map<SearchRequest>(model);

            var jsonQuery = JsonConvert.SerializeObject(request,new StringEnumConverter());

            var jsonResponse = NetworkHandler.GetAsync(jsonQuery);


            return View();
        }

    }
}
