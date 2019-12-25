using System.Data;
using System.Threading.Tasks;
using Dapper;
using ShortUrl.Domain.Entities;
using ShortUrl.Query.Factories.Contract;
using ShortUrl.Query.Handlers.Contract;

namespace ShortUrl.Query.Handlers
{
    public class ItemQueryHandler : IItemQueryHandler
    {
        #region Private Field
        private readonly IConnectionFactory _connectionFactory;
        #endregion

        #region Constructor
        public ItemQueryHandler(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        #endregion

        #region Member of IItemQueryHandler
        public async Task<Item> GetBySegmentAsync(string originUrl)
        {
            using IDbConnection connection = await _connectionFactory.GetConnectionAsync();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@originUrl", originUrl, DbType.String);

            return await connection
                .QuerySingleOrDefaultAsync<Item>("SELECT Id, Segment From Item WHERE OriginUrl = @originUrl", parameters)
                .ConfigureAwait(false);
        }

        public async Task<Item> GetByOriginUrlAsync(string segment)
        {
            using IDbConnection connection = await _connectionFactory.GetConnectionAsync();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@segment", segment, DbType.String);

            return await connection
                .QuerySingleOrDefaultAsync<Item>("SELECT Id, OriginUrl From Item WHERE Segment = @segment", parameters)
                .ConfigureAwait(false);
        }
        #endregion
    }
}