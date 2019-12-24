using System.Threading.Tasks;
using ShortUrl.Business.Models.Item;

namespace ShortUrl.Business.Contract
{
    public interface IItemBusiness
    {
        Task<ItemResponse> GenerateAsync(ItemRequest model);
    }
}