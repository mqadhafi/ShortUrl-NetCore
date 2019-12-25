using System;

namespace ShortUrl.Command.Models
{
    public class Command : ICommand
    {
        public Guid Id { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
    }
}