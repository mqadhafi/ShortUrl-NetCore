using System;

namespace ShortUrl.Commands.Models
{
    public class Command : ICommand
    {
        public Guid Id { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
    }
}