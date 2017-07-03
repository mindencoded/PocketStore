using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.Practices.Unity;
using SchoolExpress.Infrastructure.Contracts;
using SchoolExpress.Infrastructure.Helpers;
using SchoolExpress.Infrastructure.Repositories;
using SchoolExpress.Infrastructure.Uows;

namespace SchoolExpress.WebService
{
    public static class UnityConfig
    {
        public static IUnityContainer GetConfiguredContainer()
        {
            var container = new UnityContainer();
            IDictionary<Type, Func<DbContext, object>> factories = new Dictionary
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
            container.RegisterType<IRepositoryProvider, RepositoryProvider>(new HierarchicalLifetimeManager(),
                new InjectionConstructor(new RepositoryFactories(factories)));
            container.RegisterType<ISchoolExpressUow, SchoolExpressUow>(new HierarchicalLifetimeManager());
            return container;
        }
    }
}