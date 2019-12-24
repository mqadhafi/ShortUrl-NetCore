using ShortUrl.Data.Commands.Models.Item;

namespace ShortUrl.Data.Commands.Handlers.Contract
{
    public interface IItemCommandHandler :
        ICommandHandler<CreateItemCommand> // create
    { }
}