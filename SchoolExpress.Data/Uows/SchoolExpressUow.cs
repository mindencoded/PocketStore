using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using SchoolExpress.Data.Helpers;
using SchoolExpress.Data.Repositories;

namespace SchoolExpress.Data.Uows
{
    public class SchoolExpressUow : ISchoolExpressUow, IDisposable
    {
        private readonly DbContext _dbContext;

        private readonly RepositoryFactories _repositoryFactories = new RepositoryFactories(new Dictionary
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
                {typeof(ICourseScheduleDetailRepository), dbContext => new CourseScheduleDetailRepository(dbContext)},
                {typeof(ICourseScheduleRepository), dbContext => new CourseScheduleRepository(dbContext)},
                {typeof(IUserRepository), dbContext => new UserRepository(dbContext)},
                {typeof(IUserRoleRepository), dbContext => new UserRoleRepository(dbContext)},
                {typeof(IRoleRepository), dbContext => new RoleRepository(dbContext)},
                {typeof(IUserClaimRepository), dbContext => new UserClaimRepository(dbContext)},
                {typeof(IUserLoginRepository), dbContext => new UserLoginRepository(dbContext)}
            });

        private readonly IRepositoryProvider _repositoryProvider;

        public SchoolExpressUow(DbContext dbContext)
        {
            _dbContext = dbContext;
            _repositoryProvider = new RepositoryProvider(dbContext, _repositoryFactories);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IRepository<T> GetGenericRepository<T>() where T : class
        {
            return _repositoryProvider.GetRepositoryForEntityType<T>();
        }

        public T GetRepository<T>() where T : class
        {
            return _repositoryProvider.GetRepository<T>();
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_dbContext != null)
                _dbContext.Dispose();
        }

        #endregion
    }
}