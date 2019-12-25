using System;

namespace ShortUrl.Business.Models
{
    public class GeneratorRequest
    {
        public string OriginUrl { get; set; }
        public DateTimeOffset? ExpiredDate { get; set; }
        public string IpAddress { get; set; }
    }
}