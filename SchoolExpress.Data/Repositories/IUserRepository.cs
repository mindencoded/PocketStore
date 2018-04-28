using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.Data.Repositories
{
    public interface IUserRepository : IRepository<IdentityUser>
    {
        void Add(IdentityUser entity, string password);
    }
}
