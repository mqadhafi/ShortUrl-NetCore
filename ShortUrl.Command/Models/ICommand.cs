using System;

namespace ShortUrl.Commands.Models
{
    public interface ICommand
    {
        Guid Id { get; set; }
    }
}