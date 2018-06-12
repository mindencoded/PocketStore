using System;
using System.Data.Entity;
using System.Threading.Tasks;
using SchoolExpress.Data.Helpers;
using SchoolExpress.Data.Repositories;

namespace SchoolExpress.Data.Uows
{
    public class SchoolExpressUow : ISchoolExpressUow
    {
        private readonly DbContext _dbContext;

        private readonly IRepositoryProvider _repositoryProvider;

        public SchoolExpressUow(RepositoryProvider repositoryProvider)
        {
            _dbContext = repositoryProvider.DbContext;
            _repositoryProvider = repositoryProvider;
        }

        public SchoolExpressUow(DbContext dbContext, RepositoryFactories repositoryFactories)
        {
            _dbContext = dbContext;
            _repositoryProvider = new RepositoryProvider(dbContext, repositoryFactories);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IRepository<T> GetRepositoryForEntityType<T>() where T : class
        {
            return _repositoryProvider.GetRepositoryForEntityType<T>();
        }

        public T GetRepository<T>() where T : class
        {
            return _repositoryProvider.GetRepository<T>();
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_dbContext != null)
                _dbContext.Dispose();
        }

        #endregion
    }
}