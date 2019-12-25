using System;

namespace ShortUrl.Command.Models
{
    public class CreateItemCommand : Command
    {
        public string IpAddress { get; set; }
        public string OriginUrl { get; set; }
        public string Segment { get; set; }
        public DateTimeOffset? ExpiredDate { get; set; }

        public CreateItemCommand()
        {
            base.CreatedDate = DateTime.Now;
            base.Id = Guid.NewGuid();
        }
    }
}