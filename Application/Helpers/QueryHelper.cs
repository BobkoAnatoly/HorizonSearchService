using Application.Models;
using Octokit;

namespace Application.Helpers
{
    public static class QueryHelper
    {
        public static SortDirection DetectSortDirection(RepositorySearchModel request)
        {
            var predicate = request.RepoSearchSort.Split(' ').First();
            if (predicate.Contains("Больше") || predicate.Contains("Недавно"))
            {
                return SortDirection.Descending;
            }
            return SortDirection.Ascending;
        }
        public static RepoSearchSort DetectSearchSort(RepositorySearchModel request)
        {
            var predicate = request.RepoSearchSort.Split(' ').First();
            if (predicate.Contains("звёзд"))
            {
                return RepoSearchSort.Stars;
            }
            return RepoSearchSort.Updated;
        }

    }
}
