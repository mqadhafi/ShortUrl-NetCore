using System.Threading.Tasks;

namespace ShortUrl.Query.Handlers.Contract
{
    public interface IItemQueryHandler
    {
        Task<string> GetSegmentAsync(string originUrl);
        Task<string> GetOriginUrlAsync(string segment);
    }
}