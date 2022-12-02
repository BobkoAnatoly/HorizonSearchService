using Microsoft.AspNetCore.Mvc;
using Application.Models;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Application.Handlers;
using Octokit;
using Persistence.ViewModels;
using System.Reflection;
using System.Text.Json;
using Application.Helpers;

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
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public  async Task<IActionResult> Search([FromQuery] RepositorySearchModel model)
        {
            var request = _mapper.Map<SearchRequest>(model);
            QueryHelper.DetectLanguage(ref request,model);

            var jsonQuery = JsonConvert.SerializeObject(request, new StringEnumConverter());

            var jsonResponse =await NetworkHandler.GetAsync(jsonQuery);

            var response = System.Text.Json.JsonSerializer.Deserialize<SearchRepositoryResponseModel>(jsonResponse);
            var resultView = _mapper.Map<List<RepositoryModel>>(response.Repositories);

            int totalCount = response.TotalCount;
            var pager = new Pager(totalCount, model.Page, model.PerPage);

            this.ViewBag.Pager = pager;
            this.ViewBag.Result = resultView;
            return View("Index");
        }

    }
}
