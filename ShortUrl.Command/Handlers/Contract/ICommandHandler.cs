using System.Threading.Tasks;
using ShortUrl.Command.Models;

namespace ShortUrl.Command.Handlers.Contract
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}