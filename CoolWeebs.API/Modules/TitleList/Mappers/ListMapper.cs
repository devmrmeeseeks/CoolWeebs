using AutoMapper;
using CoolWebs.Model.TitleLIst;
using CoolWeebs.API.Modules.TitleList.Entities;

namespace CoolWeebs.API.Modules.TitleList.Mappers
{
    public class ListMapper : Profile
    {
        public ListMapper()
        {
            CreateMap<ListRequest, ListEntity>();

            CreateMap<ListEntity, ListResponse>();
        }

    }
}
