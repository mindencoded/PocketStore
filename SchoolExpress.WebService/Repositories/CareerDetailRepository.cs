using System.Data.Entity;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class CareerDetailRepository : Repository<CareerDetail>, ICareerDetailRepository
    {
        public CareerDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}