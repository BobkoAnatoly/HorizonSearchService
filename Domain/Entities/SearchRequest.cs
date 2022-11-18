using Octokit;

namespace Application.Models
{
    public class SearchRequest
    {
        public string SearchText { get; set; }

        public Language? Language { get; set; }

        public int PerPage = 20;

        public int Page = 1;
    }
}
