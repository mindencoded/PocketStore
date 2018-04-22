using System.Threading.Tasks;
using SchoolExpress.Data.Repositories;

namespace SchoolExpress.Data.Uows
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