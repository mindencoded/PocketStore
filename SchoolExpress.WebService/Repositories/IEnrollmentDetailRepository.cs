using System.Threading.Tasks;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public interface IEnrollmentDetailRepository : IRepository<EnrollmentDetail>
    {
        void Delete(int careerDetailId, int enrollmentId);

        Task DeleteAsync(int careerDetailId, int enrollmentId);

        EnrollmentDetail Find(int careerDetailId, int enrollmentId);

        Task<EnrollmentDetail> FindAsync(int careerDetailId, int enrollmentId);
    }
}