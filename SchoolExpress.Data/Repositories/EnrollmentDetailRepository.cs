using System.Data.Entity;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public class EnrollmentDetailRepository : Repository<EnrollmentDetail>, IEnrollmentDetailRepository
    {
        public EnrollmentDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}