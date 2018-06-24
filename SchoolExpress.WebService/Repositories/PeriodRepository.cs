using SchoolExpress.WebService.DbContexts;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class PeriodRepository : Repository<Period>, IPeriodRepository
    {
        public PeriodRepository(SchoolExpressDbContext dbContext) : base(dbContext)
        {
        }
    }
}