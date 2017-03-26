using System.Data.Entity;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.Infrastructure.Repositories
{
    public class ScheduleDetailRepository : Repository<ScheduleDetail>, IScheduleDetailRepository
    {
        public ScheduleDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}