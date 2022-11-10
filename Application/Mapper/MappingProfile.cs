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
                .ForMember(x => x.Language, o => o.MapFrom(src => src.Language));

        }
    }
}
