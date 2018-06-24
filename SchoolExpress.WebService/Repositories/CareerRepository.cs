using System.Data.Entity;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class CareerRepository : Repository<Career>, ICareerRepository
    {
        public CareerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}