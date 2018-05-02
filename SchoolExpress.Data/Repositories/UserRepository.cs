using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.Data.Repositories
{
    public class UserRepository : Repository<IdentityUser>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IdentityResult> CreateAsync(IdentityUser entity, string password)
        {
            return await new UserManager<IdentityUser>(new UserStore<IdentityUser>(DbContext)).CreateAsync(entity,
                password);
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            return await new UserManager<IdentityUser>(new UserStore<IdentityUser>(DbContext)).FindAsync(userName,
                password);
        }

        public async Task<IList<string>> GetRolesAsync(string userId)
        {
            return await new UserManager<IdentityUser>(new UserStore<IdentityUser>(DbContext)).GetRolesAsync(userId);
        }

        public async Task<IdentityResult> AddToRoleAsync(string userId, string role)
        {
            return await new UserManager<IdentityUser>(new UserStore<IdentityUser>(DbContext)).AddToRoleAsync(userId,
                role);
        }
    }
}