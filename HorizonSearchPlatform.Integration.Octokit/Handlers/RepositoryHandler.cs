using Octokit;

namespace HorizonSearchPlatform.Integration.Octokit
{
    public static class RepositoryHandler
    {
        public static void GetRepositoriesAsync()
        {
            var request = new SearchRepositoriesRequest()
            {
                SortField = RepoSearchSort.Stars,
                Language = Language.Lua
            };
        } 
    }
}
