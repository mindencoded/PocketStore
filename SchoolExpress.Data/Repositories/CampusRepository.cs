
using System.Data.Entity;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public class CampusRepository : Repository<Campus>, ICampusRepository
    {
        public CampusRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
