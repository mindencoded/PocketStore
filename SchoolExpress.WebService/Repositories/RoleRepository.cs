using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolExpress.WebService.DbContexts;

namespace SchoolExpress.WebService.Repositories
{
    public class RoleRepository : Repository<IdentityRole>, IRoleRepository
    {
        public RoleRepository(SchoolExpressDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IdentityResult> CreateAsync(IdentityRole entity)
        {
            return await new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(DbContext)).CreateAsync(entity);
        }
    }
}