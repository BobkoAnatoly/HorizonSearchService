using Application.Models;
using AutoMapper;
using Octokit;
using Persistence.ViewModels;
using System.Text.Json;

namespace HorizonSearchPlatform.Integration.Octokit
{
    public static class RepositoryHandler
    {
        
        private static readonly GitHubClient _gitHubClient;
        static RepositoryHandler()
        {
            _gitHubClient = new GitHubClient(new ProductHeaderValue("my-cool-app"));
            _gitHubClient.Credentials = new Credentials("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");
        }
        public static async Task<string> GetRepositoriesAsync(SearchRequest request,IMapper mapper)
        {
            var query = new SearchRepositoriesRequest(request.SearchText)
            {
                Language = request.Language,
                Page = request.Page,
                PerPage = request.PerPage
            };

            var response =await _gitHubClient.Search.SearchRepo(query);

            var repositories = new List<RepositoryModel>();
            foreach (var item in response.Items)
            {
                repositories.Add(new RepositoryModel
                {
                    FullName = item.FullName,
                    StarsCount = item.StargazersCount,
                    UpdatedAt = item.UpdatedAt.ToString("g"),
                    URL = item.HtmlUrl,
                    Description =item.Description,
                    Language = item.Language,
                });
            }
            var result = new SearchRepositoryResponseModel()
            {
                TotalCount = response.TotalCount,
                Repositories = repositories
            };
            

            return JsonSerializer.Serialize(result);
        }
    }
}
