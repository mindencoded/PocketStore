using System;
using System.Collections.Generic;
using System.Data.Entity;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.Infrastructure.Helpers
{
    public class RepositoryProvider : IRepositoryProvider
    {
        private readonly RepositoryFactories _repositoryFactories;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public RepositoryProvider(RepositoryFactories repositoryFactories)
        {
            _repositoryFactories = repositoryFactories;
        }

        public DbContext DbContext { get; set; }

        public IRepository<T> GetRepositoryForEntityType<T>() where T : class
        {
            return GetRepository<IRepository<T>>(_repositoryFactories.GetRepositoryFactoryForEntityType<T>());
        }

        public virtual T GetRepository<T>(Func<DbContext, object> factory = null) where T : class
        {
            // Look for T dictionary cache under typeof(T).
            object repoObj;
            _repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj != null)
                return (T)repoObj;

            // Not found or null; make one, add to dictionary cache, and return it.
            return MakeRepository<T>(factory, DbContext);
        }

        public void SetRepository<T>(T repository)
        {
            _repositories[typeof(T)] = repository;
        }

        protected virtual T MakeRepository<T>(Func<DbContext, object> factory, DbContext dbContext)
        {
            var f = factory ?? _repositoryFactories.GetRepositoryFactory<T>();
            if (f == null)
                throw new NotImplementedException("No factory for repository type, " + typeof(T).FullName);
            var repo = (T) f(dbContext);
            _repositories[typeof(T)] = repo;
            return repo;
        }
    }
}