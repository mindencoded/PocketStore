using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SchoolExpress.WebService.DbContexts;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(SchoolExpressDbContext dbContext) : base(dbContext)
        {
        }
   
        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(int userId, int personId)
        {
            UserAccount entity = DbSet.FirstOrDefault(x => x.UserId == userId && x.PersonId == personId);
            if (entity != null)
            {
                DbContext.Entry(entity).State = EntityState.Deleted;
            }
        }
        
        public override Task DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }
        
        public virtual async Task DeleteAsync(int userId, int personId)
        {
            UserAccount entity = await DbSet.FirstOrDefaultAsync(x => x.UserId == userId && x.PersonId == personId);
            if (entity != null)
            {
                DbContext.Entry(entity).State = EntityState.Deleted;
            }
        }
        
        public override UserAccount Find(object id)
        {
            throw new NotImplementedException();
        }
        
      
        public virtual UserAccount Find(int userId, int personId)
        {
            return DbSet.FirstOrDefault(x => x.UserId == userId && x.PersonId == personId);
        }
        
        public override Task<UserAccount> FindAsync(object id)
        {
            throw new NotImplementedException();
        }
        
      
        public virtual async Task<UserAccount> FindAsync(int userId, int personId)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.UserId == userId && x.PersonId == personId);
        }
    }
}
