using System;
using System.Threading.Tasks;
using SchoolExpress.WebService.Repositories;

namespace SchoolExpress.WebService.Uows
{
    public interface IUow : IDisposable
    {
        // Save pending changes to the data store.
        void Commit();

        Task CommitAsync();

        IRepository<T> GetRepositoryForEntityType<T>() where T : class;

        T GetRepository<T>() where T : class;

        void ValidateOnSaveEnabled(bool state);
    }
}