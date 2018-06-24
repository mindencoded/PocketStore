using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.WebService.Repositories
{
    public class UserRepository : Repository<IdentityUser>, IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(dbContext));
        }

        public async Task<IdentityResult> CreateAsync(IdentityUser entity, string password)
        {
            return await _userManager.CreateAsync(entity,
                password);
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            return await _userManager.FindAsync(userName, password);
        }

        public async Task<IList<string>> GetRolesAsync(string userId)
        {
            return await _userManager.GetRolesAsync(userId);
        }

        public async Task<IdentityResult> AddToRoleAsync(string userId, string role)
        {
            return await _userManager.AddToRoleAsync(userId,
                role);
        }

        public async Task<bool> IsInRole(string userId, string role)
        {
            return await _userManager.IsInRoleAsync(userId, role);
        }
    }
}