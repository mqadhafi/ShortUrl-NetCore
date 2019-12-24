using System.Threading.Tasks;
using ShortUrl.Data.Commands.Models;

namespace ShortUrl.Data.Commands.Handlers.Contract
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}