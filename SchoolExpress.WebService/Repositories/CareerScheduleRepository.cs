using System.Data.Entity;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class CareerScheduleRepository : Repository<CareerSchedule>, ICareerScheduleRepository
    {
        public CareerScheduleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}