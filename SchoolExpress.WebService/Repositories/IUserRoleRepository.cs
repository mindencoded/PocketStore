using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.WebService.Repositories
{
    public interface IUserRoleRepository : IRepository<IdentityUserRole>
    {
    }
}