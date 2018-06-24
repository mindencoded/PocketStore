using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.WebService.Repositories
{
    public class UserRoleRepository : Repository<IdentityUserRole>, IUserRoleRepository
    {
        public UserRoleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}