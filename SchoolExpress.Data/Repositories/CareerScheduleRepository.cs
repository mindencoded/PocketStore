using System.Data.Entity;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public class CareerScheduleRepository : Repository<CareerSchedule>, ICareerScheduleRepository
    {
        public CareerScheduleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}