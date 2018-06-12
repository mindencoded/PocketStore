using System.Data.Entity;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public class CareerRepository : Repository<Career>, ICareerRepository
    {
        public CareerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
