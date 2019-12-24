using System;

namespace ShortUrl.Business.Models.Item
{
    public class ItemRequest
    {
        public string OriginUrl { get; set; }
        public DateTimeOffset? ExpiredDate { get; set; }
    }
}