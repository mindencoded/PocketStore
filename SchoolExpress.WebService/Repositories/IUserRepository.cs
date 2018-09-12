using System.Threading.Tasks;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        bool IsInRole(int id, string role);
        
        Task<bool> IsInRoleAsync(int id, string role);
    }
}