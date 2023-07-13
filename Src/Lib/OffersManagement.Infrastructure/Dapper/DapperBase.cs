using System.Data;

namespace OffersManagement.Infrastructure
{
    public abstract class DapperBase
    {
        public const int SuccessDbExecute = 1;
        public readonly IDbConnection _dbProvider;

        protected DapperBase(IDbConnection provider)
        {
            _dbProvider = provider;
        }
    }
}

