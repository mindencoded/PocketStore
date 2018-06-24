using System.Data.Entity;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class CareerScheduleDetailRepository : Repository<CareerScheduleDetail>, ICareerScheduleDetailRepository
    {
        public CareerScheduleDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}