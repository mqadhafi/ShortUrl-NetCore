using System.Threading.Tasks;
using ShortUrl.Business.Models;

namespace ShortUrl.Business.Contract
{
    public interface IItemBusiness
    {
        Task<GeneratorResponse> GenerateAsync(GeneratorRequest model);
        Task<RedirectResponse> NavigatesAsync(RedirectRequest model);
    }
}