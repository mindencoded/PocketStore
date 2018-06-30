using System;
using System.Threading.Tasks;
using SchoolExpress.WebService.DbContexts;
using SchoolExpress.WebService.Repositories;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Uows
{
    public class SchoolExpressUow : ISchoolExpressUow
    {
        private readonly SchoolExpressDbContext _dbContext;

        private readonly IRepositoryProvider _repositoryProvider;

        public SchoolExpressUow(RepositoryProvider repositoryProvider)
        {
            _dbContext = (SchoolExpressDbContext) repositoryProvider.DbContext;
            _repositoryProvider = repositoryProvider;
        }

        public SchoolExpressUow(SchoolExpressDbContext dbContext, RepositoryFactories repositoryFactories)
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