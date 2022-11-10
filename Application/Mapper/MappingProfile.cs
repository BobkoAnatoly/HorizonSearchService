using Application.Helpers;
using Application.Models;
using AutoMapper;
using Octokit;
using Persistence.ViewModels;

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
            CreateMap<Repository, RepositoryModel>()
                .ForMember(x => x.URL, o => o.MapFrom(src => src.HtmlUrl))
                .ForMember(x => x.FullName, o => o.MapFrom(src => src.FullName))
                .ForMember(x => x.UpdatedAt, o => o.MapFrom(src => src.UpdatedAt))
                .ForMember(x => x.StarsCount, o => o.MapFrom(src => src.StargazersCount));

        }
    }
}
