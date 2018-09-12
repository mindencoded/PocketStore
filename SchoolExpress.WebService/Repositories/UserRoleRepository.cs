using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(DbContext dbContext) : base(dbContext)
        {
        }
        
        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(int userId, int roleId)
        {
            UserRole entity = DbSet.FirstOrDefault(x => x.UserId == userId && x.RoleId == roleId);
            if (entity != null)
            {
                DbContext.Entry(entity).State = EntityState.Deleted;
            }
        }
        
        public override Task DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }
        
        public virtual async Task DeleteAsync(int userId, int roleId)
        {
            UserRole entity = await DbSet.FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId);
            if (entity != null)
            {
                DbContext.Entry(entity).State = EntityState.Deleted;
            }
        }
        
        public override UserRole Find(object id)
        {
            throw new NotImplementedException();
        }
        
      
        public virtual UserRole Find(int userId, int roleId)
        {
            return DbSet.FirstOrDefault(x => x.UserId == userId && x.RoleId == roleId);
        }
        
        public override Task<UserRole> FindAsync(object id)
        {
            throw new NotImplementedException();
        }
        
      
        public virtual async Task<UserRole> FindAsync(int userId, int roleId)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId);
        }
    }
}