using System;

namespace ShortUrl.Command.Models
{
    public class CreateStatisticCommand : Command
    {
        public string IpAddress { get; set; }
        public Guid ItemId { get; set; }

        public CreateStatisticCommand()
        {
            base.CreatedDate = DateTime.Now;
            base.Id = Guid.NewGuid();
        }
    }
}