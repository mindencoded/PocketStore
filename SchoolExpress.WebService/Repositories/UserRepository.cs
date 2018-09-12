using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SchoolExpress.WebService.DbContexts;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class UserRepository :  Repository<User>, IUserRepository
    {
        public UserRepository(SchoolExpressDbContext dbContext) : base(dbContext)
        {
        }

        public bool IsInRole(int id, string role)
        {
            dynamic user = DbSet.AsNoTracking().Include("UserRole.Role").Where(x => x.Id == id).Select(x => new
            {
                Roles = x.UserRoles.Select(y => y.Role.Name).ToArray()
            }).FirstOrDefault();
            if (user != null)
            {
                if (user.Roles.Contains(role))
                {
                    return true;
                }       
            }
            return false;
        }

        public async Task<bool> IsInRoleAsync(int id, string role)
        {
            dynamic user = await DbSet.AsNoTracking().Include("UserRole.Role").Where(x => x.Id == id).Select(x => new
            {
                Roles = x.UserRoles.Select(y => y.Role.Name).ToArray()
            }).FirstOrDefaultAsync();
            if (user != null)
            {
                if (user.Roles.Contains(role))
                {
                    return true;
                }       
            }
            return false;
        }
    }
}