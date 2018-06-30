using System;
using System.Collections.Generic;
using System.Data.Entity;
using SchoolExpress.WebService.Repositories;

namespace SchoolExpress.WebService.Utils
{
    public class RepositoryProvider : IRepositoryProvider
    {
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        private readonly RepositoryFactories _repositoryFactories;

        public RepositoryProvider(DbContext dbContext, RepositoryFactories repositoryFactories)
        {
            DbContext = dbContext;
            _repositoryFactories = repositoryFactories;
        }


        public DbContext DbContext { get; }

        public IRepository<T> GetRepositoryForEntityType<T>() where T : class
        {
            return GetRepository<IRepository<T>>(_repositoryFactories.GetRepositoryFactoryForEntityType<T>());
        }

        public virtual T GetRepository<T>(Func<DbContext, object> factory) where T : class
        {
            // Look for T dictionary cache under typeof(T).
            object repoObj;
            _repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj != null)
                return (T) repoObj;

            // Not found or null; make one, add to dictionary cache, and return it.
            return MakeRepository<T>(factory, DbContext);
        }

        public virtual T GetRepository<T>() where T : class
        {
            // Look for T dictionary cache under typeof(T).
            object repoObj;
            _repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj != null)
                return (T) repoObj;
            Func<DbContext, object> factory = _repositoryFactories.GetRepositoryFactory<T>();
            // Not found or null; make one, add to dictionary cache, and return it.
            return MakeRepository<T>(factory, DbContext);
        }

        public void SetRepository<T>(T repository)
        {
            _repositories[typeof(T)] = repository;
        }

        protected virtual T MakeRepository<T>(Func<DbContext, object> factory, DbContext dbContext)
        {
            Func<DbContext, object> f = factory ?? _repositoryFactories.GetRepositoryFactory<T>();
            if (f == null)
                throw new NotImplementedException("No factory for repository type, " + typeof(T).FullName);
            T repo = (T) f(dbContext);
            _repositories[typeof(T)] = repo;
            return repo;
        }
    }
}