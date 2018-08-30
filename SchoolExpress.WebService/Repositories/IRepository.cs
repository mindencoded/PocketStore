using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolExpress.WebService.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAll();
        T GetById(object id);
        Task<T> GetByIdAsync(object id);
        void Add(T entity);
        void Update(T entity);
        void Update(ExpandoObject expObj);
        void Delete(T entity);
        void Delete(object id);
    }
}