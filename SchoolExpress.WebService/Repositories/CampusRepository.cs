using SchoolExpress.WebService.DbContexts;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class CampusRepository : Repository<Campus>, ICampusRepository
    {
        public CampusRepository(SchoolExpressDbContext dbContext) : base(dbContext)
        {
        }
    }
}