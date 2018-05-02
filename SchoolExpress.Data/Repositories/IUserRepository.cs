using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.Data.Repositories
{
    public interface IUserRepository : IRepository<IdentityUser>
    {
        Task<IdentityResult> CreateAsync(IdentityUser entity, string password);

        Task<IdentityUser> FindUser(string userName, string password);

        Task<IList<string>> GetRolesAsync(string userId);

        Task<IdentityResult> AddToRoleAsync(string userId, string role);
    }
}