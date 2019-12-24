using System;

namespace ShortUrl.Data.Commands.Models
{
    public interface ICommand
    {
        Guid Id { get; set; }
    }
}