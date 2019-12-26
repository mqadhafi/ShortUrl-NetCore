using System.Threading.Tasks;
using ShortUrl.Domain.Entities;

namespace ShortUrl.Query.Handlers.Contract
{
    public interface IItemQueryHandler
    {
        Task<Item> GetByOriginUrlAsync(string originUrl);
        Task<Item> GetBySegmentAsync(string segment);
    }
}