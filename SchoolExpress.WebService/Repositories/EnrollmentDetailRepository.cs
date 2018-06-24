using SchoolExpress.WebService.DbContexts;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class EnrollmentDetailRepository : Repository<EnrollmentDetail>, IEnrollmentDetailRepository
    {
        public EnrollmentDetailRepository(SchoolExpressDbContext dbContext) : base(dbContext)
        {
        }
    }
}