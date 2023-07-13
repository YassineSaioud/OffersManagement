using System.Data;

namespace OffersManagement.Infrastructure
{
    public interface IDapperWrapper
    {
        Task<IEnumerable<T>> QueryAsync<T>(IDbConnection provider, string sql, object parameters = null, IDbTransaction transaction = null);
        Task<T> QuerySingleAsync<T>(IDbConnection provider, string sql, object parameters = null, IDbTransaction transaction = null);
        Task<int> ExecuteAsync(IDbConnection provider, string sql, object parameters = null, IDbTransaction transaction = null);
    }
}

