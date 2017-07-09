using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using SchoolExpress.Infrastructure.Contracts;
using SchoolExpress.Infrastructure.Helpers;
using SchoolExpress.Infrastructure.Repositories;

namespace SchoolExpress.Infrastructure.Uows
{
    public class SchoolExpressUow : ISchoolExpressUow, IDisposable
    {
        private readonly DbContext _dbContext;

        private readonly IDictionary<Type, Func<DbContext, object>> _factories = new Dictionary
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

        private readonly IRepositoryProvider _repositoryProvider;

        public SchoolExpressUow(DbContext dbContext)
        {
            _dbContext = dbContext;
            _repositoryProvider = new RepositoryProvider(dbContext, new RepositoryFactories(_factories));
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
            if (disposing)
                if (_dbContext != null)
                    _dbContext.Dispose();
        }

        #endregion
    }
}