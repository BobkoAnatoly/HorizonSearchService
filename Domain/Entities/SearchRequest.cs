using Persistence.Enums;

namespace Persistence.Models
{
    public class SearchRequest
    {
        public string SearchText { get; set; }
        public SortType SortType { get; set; }
        public LanguageNames Language { get; set; }
    }
}
