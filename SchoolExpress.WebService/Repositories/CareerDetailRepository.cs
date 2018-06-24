using SchoolExpress.WebService.DbContexts;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class CareerDetailRepository : Repository<CareerDetail>, ICareerDetailRepository
    {
        public CareerDetailRepository(SchoolExpressDbContext dbContext) : base(dbContext)
        {
        }
    }
}