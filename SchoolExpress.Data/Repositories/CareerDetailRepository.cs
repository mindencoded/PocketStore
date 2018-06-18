
using System.Data.Entity;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public class CareerDetailRepository : Repository<CareerDetail>, ICareerDetailRepository
    {
        public CareerDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
