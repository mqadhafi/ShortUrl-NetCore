using System.Threading.Tasks;
using ShortUrl.Business.Models;

namespace ShortUrl.Business.Contract
{
    public interface IItemBusiness
    {
        Task<Response> GenerateAsync(ItemModel model);
    }
}