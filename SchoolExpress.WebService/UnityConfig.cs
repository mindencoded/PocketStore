using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SchoolExpress.Data.DbContexts;
using SchoolExpress.Data.Helpers;
using SchoolExpress.Data.Repositories;
using SchoolExpress.Data.Uows;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace SchoolExpress.WebService
{
    public static class UnityConfig
    {
        public static IUnityContainer GetContainer()
        {
            UnityContainer container = new UnityContainer();
            IDictionary<Type, Func<DbContext, object>> factories = new Dictionary
                <Type, Func<DbContext, object>>();
            container.RegisterType<DbContext, SchoolExpressDbContext>(new PerThreadLifetimeManager());
            Type[] repositoryTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(t => t.GetInterfaces()
                                .Count(i => i.IsGenericType &&
                                            i.GetGenericTypeDefinition() ==
                                            typeof(IRepository<>) && t.IsClass && t != typeof(Repository<>)) >
                            0).ToArray();
            foreach (Type repositoryType in repositoryTypes)
            {
                Type contractType = repositoryType.GetInterfaces()
                    .FirstOrDefault(p => !p.IsGenericType && p != typeof(IDisposable));
                if (contractType != null)
                {
                    container.RegisterType(contractType, repositoryType);
                    factories.Add(contractType, dbContext => Activator.CreateInstance(repositoryType, dbContext));
                }
            }

            container.RegisterType<RepositoryFactories>(new InjectionConstructor(factories));
            container.RegisterType<ISchoolExpressUow, SchoolExpressUow>();
            return container;
        }
    }
}