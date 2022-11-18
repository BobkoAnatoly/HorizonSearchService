
namespace Persistence.ViewModels
{
    public class SearchRepositoryResponseModel
    {
        public int TotalCount { get; set; }
        public List<RepositoryModel> Repositories { get; set; }
    }
}
