using AutoMapper;
using CoolWebs.Model.TitleLIst;
using CoolWeebs.API.Modules.TitleList.Entities;

namespace CoolWeebs.API.Modules.TitleList.Mappers
{
    public class TitleMapper : Profile
    {
        public TitleMapper()
        {
            CreateMap<TitleRequest, TitleEntity>();

            CreateMap<TitleEntity, TitleResponse>();
        }
    }
}
