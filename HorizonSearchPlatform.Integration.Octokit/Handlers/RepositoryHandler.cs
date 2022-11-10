using Application.Models;
using Newtonsoft.Json;
using Octokit;

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
        public static async Task<string> GetRepositoriesAsync(SearchRequest request)
        {
            var query = new SearchRepositoriesRequest(request.SearchText)
            {
                Language = request.Language,
                Order = request.SortDirection,
                SortField = request.RepoSearchSort,
                Page = request.Page,
                PerPage = request.PerPage
            };

            var result =await _gitHubClient.Search.SearchRepo(query);
            return JsonConvert.SerializeObject(result);
        }
    }
}
