using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

        public UserManager<IdentityUser> UserManager()
        {
            return new UserManager<IdentityUser>(new UserStore<IdentityUser>(_dbContext));
        }
        
        public RoleManager<IdentityRole> RoleManager()
        {
            return new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_dbContext));
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