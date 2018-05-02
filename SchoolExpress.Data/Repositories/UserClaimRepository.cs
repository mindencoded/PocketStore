using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.Data.Repositories
{
    public class UserClaimRepository : Repository<IdentityUserClaim>, IUserClaimRepository
    {
        public UserClaimRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}