using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.Data.Repositories
{
    public class UserRoleRepository : Repository<IdentityUserRole>, IUserRoleRepository
    {
        public UserRoleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
