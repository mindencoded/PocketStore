using System.Data.Entity;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.Infrastructure.Repositories
{
    public class EnrollmentDetailRepository : Repository<EnrollmentDetail>, IEnrollmentDetailRepository
    {
        public EnrollmentDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}