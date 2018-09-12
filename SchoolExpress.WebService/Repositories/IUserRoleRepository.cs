using System.Threading.Tasks;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public interface IUserRoleRepository :  IRepository<UserRole>
    {
        void Delete(int userId, int roleId);
        
        Task DeleteAsync(int careerDetailId, int enrollmentId);

        UserRole Find(int userId, int roleId);
        
        Task<UserRole> FindAsync(int userId, int roleId);
    }
}