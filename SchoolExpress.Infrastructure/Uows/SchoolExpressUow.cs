using System;
using System.Threading.Tasks;
using SchoolExpress.Infrastructure.Contracts;
using SchoolExpress.Infrastructure.DbContexts;
using SchoolExpress.Infrastructure.Helpers;

namespace SchoolExpress.Infrastructure.Uows
{
    public class SchoolExpressUow : ISchoolExpressUow, IDisposable
    {
        private readonly SchoolExpressDbContext _dbContext;

        public SchoolExpressUow(IRepositoryProvider repositoryProvider, SchoolExpressDbContext dbContext)
        {
            _dbContext = dbContext;
            RepositoryProvider = repositoryProvider;
            repositoryProvider.DbContext = _dbContext;
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IRepository<T> GetGenericRepository<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        public T GetRepository<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (_dbContext != null)
                    _dbContext.Dispose();
        }

        #endregion
    }
}