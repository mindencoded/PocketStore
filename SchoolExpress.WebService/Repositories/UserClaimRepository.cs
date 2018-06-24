using Microsoft.AspNet.Identity.EntityFramework;
using SchoolExpress.WebService.DbContexts;

namespace SchoolExpress.WebService.Repositories
{
    public class UserClaimRepository : Repository<IdentityUserClaim>, IUserClaimRepository
    {
        public UserClaimRepository(SchoolExpressDbContext dbContext) : base(dbContext)
        {
        }
    }
}