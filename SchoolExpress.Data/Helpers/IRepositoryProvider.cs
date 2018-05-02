using System;
using System.Data.Entity;
using SchoolExpress.Data.Repositories;

namespace SchoolExpress.Data.Helpers
{
    public interface IRepositoryProvider
    {
        DbContext DbContext { get; }

        IRepository<T> GetRepositoryForEntityType<T>() where T : class;

        T GetRepository<T>(Func<DbContext, object> factory) where T : class;

        T GetRepository<T>() where T : class;

        void SetRepository<T>(T repository);
    }
}