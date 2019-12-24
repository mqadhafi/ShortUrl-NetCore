using System.Threading.Tasks;

namespace ShortUrl.Query.Handlers.Contract
{
    public interface IItemQueryHandler
    {
        Task<string> IsExistAsync(string originUrl);
    }
}