using System.Threading.Tasks;
using ShortUrl.Commands.Models;

namespace ShortUrl.Commands.Handlers.Contract
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}