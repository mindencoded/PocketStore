using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using SchoolExpress.Infrastructure.Contracts;
using SchoolExpress.Infrastructure.DbContexts;
using SchoolExpress.Infrastructure.Helpers;
using SchoolExpress.Infrastructure.Repositories;

namespace SchoolExpress.Infrastructure.Uows
{
    public class SchoolExpressUow : ISchoolExpressUow, IDisposable
    {
        private static readonly IDictionary<Type, Func<DbContext, object>> Factories = new Dictionary
            <Type, Func<DbContext, object>>
            {
                {typeof(IAcademicTermRepository), dbContext => new AcademicTermRepository(dbContext)},
                {typeof(IAssignmentRepository), dbContext => new AssignmentRepository(dbContext)},
                {typeof(IClassRoomRepository), dbContext => new ClassRoomRepository(dbContext)},
                {typeof(ICourseRepository), dbContext => new CourseRepository(dbContext)},
                {typeof(IEnrollmentDetailRepository), dbContext => new EnrollmentDetailRepository(dbContext)},
                {typeof(IEnrollmentRepository), dbContext => new EnrollmentRepository(dbContext)},
                {typeof(IGradeRepository), dbContext => new GradeRepository(dbContext)},
                {typeof(IPersonRepository), dbContext => new PersonRepository(dbContext)},
                {typeof(IRoleRepository), dbContext => new RoleRepository(dbContext)},
                {typeof(IScheduleDetailRepository), dbContext => new ScheduleDetailRepository(dbContext)},
                {typeof(IScheduleRepository), dbContext => new ScheduleRepository(dbContext)},
                {typeof(IUserRepository), dbContext => new UserRepository(dbContext)}
            };

        public SchoolExpressUow(IRepositoryProvider repositoryProvider, SchoolExpressDbContext dbContext)
        {
            DbContext = dbContext;
            repositoryProvider.DbContext = DbContext;
            repositoryProvider.SetFactories(Factories);
            RepositoryProvider = repositoryProvider;
        }

        private SchoolExpressDbContext DbContext { get; }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public IRepository<T> GetGenericRepository<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        public T GetRepository<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (DbContext != null)
                    DbContext.Dispose();
        }

        #endregion
    }
}