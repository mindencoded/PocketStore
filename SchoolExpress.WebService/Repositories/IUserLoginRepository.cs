using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.WebService.Repositories
{
    public interface IUserLoginRepository : IRepository<IdentityUserLogin>
    {
    }
}