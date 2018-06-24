using SchoolExpress.WebService.DbContexts;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class CareerScheduleRepository : Repository<CareerSchedule>, ICareerScheduleRepository
    {
        public CareerScheduleRepository(SchoolExpressDbContext dbContext) : base(dbContext)
        {
        }
    }
}