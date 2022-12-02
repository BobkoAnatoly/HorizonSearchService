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
                PerPage = request.PerPage,
                SortField = RepoSearchSort.Stars,
                Order = SortDirection.Descending,
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
