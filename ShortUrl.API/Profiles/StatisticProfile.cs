using AutoMapper;
using ShortUrl.Commands.Models;
using ShortUrl.Domain.Entities;

namespace ShortUrl.API.Profiles
{
    public class StatisticProfile : Profile
    {
        public StatisticProfile()
        {
            CreateMap<CreateStatisticCommand, Statistic>();
        }
    }
}