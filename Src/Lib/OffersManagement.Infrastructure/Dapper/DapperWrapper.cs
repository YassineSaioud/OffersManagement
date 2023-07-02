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

        public IEnumerable<T> Query<T>(string sql, object parameters = null)
        {
            return _connection.Query<T>(sql, parameters);
        }

        public T QuerySingle<T>(string sql, object parameters = null)
        {
            return _connection.QuerySingle<T>(sql, parameters);
        }

        public int Execute(string sql, object parameters = null)
        {
            return _connection.Execute(sql, parameters);
        }

       
    }
}
