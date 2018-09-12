
using System.Threading.Tasks;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        void Delete(int userId, int personId);
        
        Task DeleteAsync(int careerDetailId, int enrollmentId);

        UserAccount Find(int userId, int personId);

        Task<UserAccount> FindAsync(int userId, int personId);
    }
}
