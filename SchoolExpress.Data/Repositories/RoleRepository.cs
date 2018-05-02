using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.Data.Repositories
{
    public class RoleRepository : Repository<IdentityRole>, IRoleRepository
    {
        public RoleRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IdentityResult> CreateAsync(IdentityRole entity)
        {
            return await new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(DbContext)).CreateAsync(entity);
        }
    }
}