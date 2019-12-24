using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ShortUrl.Query.Factories.Contract;

namespace ShortUrl.Query.Factories
{
    public class SqlServerConnectionFactory : IConnectionFactory
    {
        #region Private Field
        private readonly string _connectionString;
        #endregion

        #region Constructor
        public SqlServerConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region Member of IConnectionFactory
        public async Task<IDbConnection> GetConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync().ConfigureAwait(false);

            return connection;
        }
        #endregion
    }
}