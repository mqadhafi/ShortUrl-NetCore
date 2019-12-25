using System;

namespace ShortUrl.Domain.Entities
{
    public class Statistic : BaseEntity
    {
        public string IpAddress { get; set; }
        public Guid ItemId { get; set; }
    }
}