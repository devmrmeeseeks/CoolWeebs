using AutoMapper;
using CoolWebs.Model.TitleLIst;
using CoolWeebs.API.Modules.TitleList.Entities;
using CoolWeebs.API.Modules.TitleList.Models;

namespace CoolWeebs.API.Modules.TitleList.Mappers
{
    public class TitleMapper : Profile
    {
        public TitleMapper()
        {
            CreateMap<TitleRequest, TitleEntity>();

            CreateMap<TitleEntity, TitleResponse>();

            CreateMap<TitleExternalData, TitleEntity>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title));
        }
    }
}
