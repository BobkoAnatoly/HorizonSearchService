using Application.Helpers;
using Application.Models;
using AutoMapper;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RepositorySearchModel, SearchRequest>()
                .ForMember(x => x.SearchText, o => o.MapFrom(src => src.SearchString))
                .ForMember(x => x.Language, o => o.MapFrom(src => src.Language))
                .ForMember(x => x.SortDirection, o => o.MapFrom(src => QueryHelper.DetectSortDirection(src)))
                .ForMember(x => x.RepoSearchSort, o => o.MapFrom(src => QueryHelper.DetectSearchSort(src)));
                
        }
    }
}
