using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Access.Primitives.EFCore
{
    public class RepositoryFactory<T> where T : DbContext
    {
        private readonly T _dbContext;

        public RepositoryFactory(T dbContext)
        {
            _dbContext = dbContext;
        }

        public IDbConnection Connection => _dbContext.Database.GetDbConnection();
    }
}