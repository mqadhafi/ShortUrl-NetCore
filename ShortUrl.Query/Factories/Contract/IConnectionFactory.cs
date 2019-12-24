using System.Data;
using System.Threading.Tasks;

namespace ShortUrl.Query.Factories.Contract
{
    public interface IConnectionFactory
    {
        Task<IDbConnection> GetConnectionAsync();
    }
}