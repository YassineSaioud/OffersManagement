using Dapper;
using System.Data;

namespace OffersManagement.Infrastructure
{
    public class DapperWrapper
        : IDapperWrapper
    {

        public async Task<IEnumerable<T>> QueryAsync<T>(IDbConnection provider, string sql, object parameters = null, IDbTransaction transaction = null)
        {
            return await provider.QueryAsync<T>(sql, parameters, transaction);
        }

        public async Task<T> QuerySingleAsync<T>(IDbConnection provider, string sql, object parameters = null, IDbTransaction transaction = null)
        {
            return await provider.QuerySingleAsync<T>(sql, parameters, transaction);
        }

        public async Task<int> ExecuteAsync(IDbConnection provider, string sql, object parameters = null, IDbTransaction transaction = null)
        {
            return await provider.ExecuteAsync(sql, parameters, transaction);
        }

    }
}
