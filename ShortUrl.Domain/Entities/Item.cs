using System;

namespace ShortUrl.Domain.Entities
{
    public class Item : BaseEntity
    {
        public string OriginUrl { get; set; }
        public string Segment { get; set; }
        public DateTimeOffset? ExpiredDate { get; set; }
    }
}