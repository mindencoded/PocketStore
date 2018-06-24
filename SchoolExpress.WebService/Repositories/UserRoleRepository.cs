using Microsoft.AspNet.Identity.EntityFramework;
using SchoolExpress.WebService.DbContexts;

namespace SchoolExpress.WebService.Repositories
{
    public class UserRoleRepository : Repository<IdentityUserRole>, IUserRoleRepository
    {
        public UserRoleRepository(SchoolExpressDbContext dbContext) : base(dbContext)
        {
        }
    }
}