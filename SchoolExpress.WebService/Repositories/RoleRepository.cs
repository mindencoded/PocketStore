using System.Data.Entity;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}