namespace OffersManagement.Host.WebApi.Integration.Tests
{
    public interface IDapperWrapperMock
    {
        IEnumerable<T> Query<T>(string sql, object parameters = null);
        T QuerySingle<T>(string sql, object parameters = null);
        int Execute(string sql, object parameters = null);
    }
}

