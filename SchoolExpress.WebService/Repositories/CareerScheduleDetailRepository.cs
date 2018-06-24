using SchoolExpress.WebService.DbContexts;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class CareerScheduleDetailRepository : Repository<CareerScheduleDetail>, ICareerScheduleDetailRepository
    {
        public CareerScheduleDetailRepository(SchoolExpressDbContext dbContext) : base(dbContext)
        {
        }
    }
}