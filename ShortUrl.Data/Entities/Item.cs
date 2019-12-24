using System;

namespace ShortUrl.Data.Entities
{
    public class Item : BaseEntity
    {
        public string OriginUrl { get; set; }
        public string Segment { get; set; }
        public DateTimeOffset ExpiredDate { get; set; }
    }
}