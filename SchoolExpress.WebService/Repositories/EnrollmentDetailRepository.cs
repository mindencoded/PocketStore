using System.Data.Entity;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class EnrollmentDetailRepository : Repository<EnrollmentDetail>, IEnrollmentDetailRepository
    {
        public EnrollmentDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}