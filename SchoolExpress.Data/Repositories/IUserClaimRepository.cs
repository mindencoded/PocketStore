using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.Data.Repositories
{
    public interface IUserClaimRepository : IRepository<IdentityUserClaim>
    {
    }
}
