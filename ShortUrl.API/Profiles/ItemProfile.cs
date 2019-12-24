using AutoMapper;
using ShortUrl.Data.Commands.Models.Item;
using ShortUrl.Data.Entities;

namespace ShortUrl.API.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<CreateItemCommand, Item>();
        }
    }
}