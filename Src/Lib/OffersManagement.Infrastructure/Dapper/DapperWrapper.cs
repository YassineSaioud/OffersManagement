using Dapper;
using System.Data;

namespace OffersManagement.Infrastructure
{
    public class DapperWrapper
        : IDapperWrapper
    {

        private readonly IDbConnection _connection;

        public DapperWrapper(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
        {
            return await _connection.QueryAsync<T>(sql, parameters);
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object parameters = null)
        {
            return await _connection.QuerySingleAsync<T>(sql, parameters);
        }

        public async Task<int> ExecuteAsync(string sql, object parameters = null)
        {
            return await _connection.ExecuteAsync(sql, parameters);
        }


    }
}
