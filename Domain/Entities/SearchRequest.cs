using Octokit;

namespace Application.Models
{
    public class SearchRequest
    {
        public string SearchText { get; set; }

        public RepoSearchSort RepoSearchSort { get; set; }

        public SortDirection SortDirection { get; set; }

        public Language Language { get; set; }

        public int PerPage { get; set; } = 20;

        public int Page { get; set; }
    }
}
