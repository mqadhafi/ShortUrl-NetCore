using System.Threading.Tasks;
using ShortUrl.Domain.Entities;

namespace ShortUrl.Query.Handlers.Contract
{
    public interface IItemQueryHandler
    {
        Task<Item> GetBySegmentAsync(string originUrl);
        Task<Item> GetByOriginUrlAsync(string segment);
    }
}