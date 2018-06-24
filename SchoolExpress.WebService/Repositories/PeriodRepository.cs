using System.Data.Entity;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class PeriodRepository : Repository<Period>, IPeriodRepository
    {
        public PeriodRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}