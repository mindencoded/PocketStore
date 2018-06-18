using System.Data.Entity;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public class CareerScheduleDetailRepository : Repository<CareerScheduleDetail>, ICareerScheduleDetailRepository
    {
        public CareerScheduleDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}