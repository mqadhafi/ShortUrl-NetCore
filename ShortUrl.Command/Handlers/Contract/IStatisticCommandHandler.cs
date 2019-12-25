using ShortUrl.Command.Models;

namespace ShortUrl.Command.Handlers.Contract
{
    public interface IStatisticCommandHandler :
        ICommandHandler<CreateStatisticCommand> // create
    { }
}