using Microsoft.AspNet.Identity.EntityFramework;
using SchoolExpress.WebService.DbContexts;

namespace SchoolExpress.WebService.Repositories
{
    public class UserLoginRepository : Repository<IdentityUserLogin>, IUserLoginRepository
    {
        public UserLoginRepository(SchoolExpressDbContext dbContext) : base(dbContext)
        {
        }
    }
}