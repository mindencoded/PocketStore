using System.Data.Entity;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class CampusRepository : Repository<Campus>, ICampusRepository
    {
        public CampusRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}