using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SchoolExpress.WebService.DbContexts;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class EnrollmentDetailRepository : Repository<EnrollmentDetail>, IEnrollmentDetailRepository
    {
        public EnrollmentDetailRepository(SchoolExpressDbContext dbContext) : base(dbContext)
        {}
        
        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(int careerDetailId, int enrollmentId)
        {
            EnrollmentDetail entity = DbSet.FirstOrDefault(x => x.CareerDetailId == careerDetailId && x.EnrollmentId == enrollmentId);
            if (entity != null)
            {
                DbContext.Entry(entity).State = EntityState.Deleted;
            }
        }
        
        public override Task DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task DeleteAsync(int careerDetailId, int enrollmentId)
        {
            EnrollmentDetail entity = await DbSet.FirstOrDefaultAsync(x => x.CareerDetailId == careerDetailId && x.EnrollmentId == enrollmentId);
            if (entity != null)
            {
                DbContext.Entry(entity).State = EntityState.Deleted;
            }
        }
        
        public override EnrollmentDetail Find(object id)
        {
            throw new NotImplementedException();
        }
        
      
        public virtual EnrollmentDetail Find(int careerDetailId, int enrollmentId)
        {
            return DbSet.FirstOrDefault(x => x.CareerDetailId == careerDetailId && x.EnrollmentId == enrollmentId);
        }
        
        public override Task<EnrollmentDetail> FindAsync(object id)
        {
            throw new NotImplementedException();
        }
        
        public virtual async Task<EnrollmentDetail> FindAsync(int careerDetailId, int enrollmentId)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.CareerDetailId == careerDetailId && x.EnrollmentId == enrollmentId);
        }
    }
}