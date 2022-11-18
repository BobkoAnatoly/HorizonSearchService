using AutoMapper;
using Octokit;
using Persistence.ViewModels;

namespace HorizonSearchPlatform.Server.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<SearchRepositoryResult, SearchRepositoryResponseModel>()
                .ForMember(x => x.TotalCount, o => o.MapFrom(src => src.TotalCount))
                .ForMember(x => x.Repositories, o => o.MapFrom(src => src.Items));

        }
    }
}
