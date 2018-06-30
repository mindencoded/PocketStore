using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolExpress.WebService.DbContexts;
using SchoolExpress.WebService.Repositories;
using SchoolExpress.WebService.Uows;
using SchoolExpress.WebService.Utils;
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
            container.RegisterType<SchoolExpressDbContext>(new PerThreadLifetimeManager());
            IDictionary<Type, Func<DbContext, object>> factories = new Dictionary<Type, Func<DbContext, object>>();
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
            container.RegisterType<IUserStore<IdentityUser>, UserStore<IdentityUser>>(
                new InjectionConstructor(container.Resolve<SchoolExpressDbContext>()));
            return container;
        }
    }
}