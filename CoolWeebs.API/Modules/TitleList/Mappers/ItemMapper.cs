using AutoMapper;
using CoolWebs.Model.TitleLIst;
using CoolWeebs.API.Modules.TitleList.Entities;

namespace CoolWeebs.API.Modules.TitleList.Mappers
{
    public class ItemMapper : Profile
    {
        public ItemMapper()
        {
            CreateMap<ItemRequest, ItemEntity>();

            CreateMap<ItemEntity, ItemResponse>()
                .ForMember(s => s.Title, opt => opt.Ignore());
        }
    }
}
