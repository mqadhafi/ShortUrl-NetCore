using System;

namespace ShortUrl.Command.Models
{
    public interface ICommand
    {
        Guid Id { get; set; }
    }
}