using System.Threading.Tasks;

namespace SchoolExpress.Infrastructure.Contracts
{
    public interface IUow
    {
        // Save pending changes to the data store.
        void Commit();

        Task CommitAsync();

        IRepository<T> GetGenericRepository<T>() where T : class;

        T GetRepository<T>() where T : class;
    }
}