namespace OffersManagement.Infrastructure
{
    public interface IDapperWrapper
    {
        IEnumerable<T> Query<T>(string sql, object parameters = null);
        T QuerySingle<T>(string sql, object parameters = null);
        int Execute(string sql, object parameters = null);
    }
}

