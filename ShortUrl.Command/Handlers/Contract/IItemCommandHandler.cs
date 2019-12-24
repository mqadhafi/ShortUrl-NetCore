using ShortUrl.Commands.Models;

namespace ShortUrl.Commands.Handlers.Contract
{
    public interface IItemCommandHandler :
        ICommandHandler<CreateItemCommand> // create
    { }
}