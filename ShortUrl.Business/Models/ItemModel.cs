using System;

namespace ShortUrl.Business.Models
{
    public class ItemModel
    {
        public string OriginUrl { get; set; }
        public DateTimeOffset? ExpiredDate { get; set; }
    }
}