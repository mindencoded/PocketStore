using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolExpress.WebService.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetQueryable();
        void Add(T entity);
        void Update(T entity);
        void Update(ExpandoObject expObj);
        void Delete(T entity);
        void Delete(object id);
        Task DeleteAsync(object id);
        void Detach(T entity);
        T Find(object id);
        Task<T> FindAsync(object id);
    }
}