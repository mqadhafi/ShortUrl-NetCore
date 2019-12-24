using AutoMapper;
using ShortUrl.Commands.Models;
using ShortUrl.Domain.Entities;

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