using ShortUrl.Command.Models;

namespace ShortUrl.Command.Handlers.Contract
{
    public interface IItemCommandHandler :
        ICommandHandler<CreateItemCommand> // create
    { }
}