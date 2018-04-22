using System.Data.Entity;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}