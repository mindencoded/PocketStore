using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Npgsql;
using SchoolExpress.WebService.DbContexts;
using SchoolExpress.WebService.Helpers;
using SchoolExpress.WebService.Repositories;
using SchoolExpress.WebService.Uows;
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
            string schoolExpressConnection = ConfigurationManager.AppSettings["SchoolExpressConnection"];
            ConnectionStringSettings connectionStringSettings =
                @ConfigurationManager.ConnectionStrings[schoolExpressConnection];
            string providerName = connectionStringSettings.ProviderName;
            string connectionString = connectionStringSettings.ConnectionString;

            if (providerName == "Npgsql")
            {
                DbConfiguration.Loaded += (_, a) =>
                {
                    //a.ReplaceService<DbProviderServices>((s, k) => new NpgsqlServices());
                    //a.ReplaceService<IProviderInvariantName>((s, k) => new CustomProviderInvariantName(providerName));
                    a.ReplaceService<IDbConnectionFactory>((s, k) => new NpgsqlConnectionFactory());
                };
            }
            else if (providerName == "System.Data.SqlClient")
            {
                DbConfiguration.Loaded += (_, a) =>
                {
                    //a.ReplaceService<DbProviderServices>((s, k) => SqlProviderServices.Instance);
                    //a.ReplaceService<IProviderInvariantName>((s, k) => new CustomProviderInvariantName(providerName));
                    if (connectionString.Contains("MSSQLLocalDB"))
                    {
                        a.ReplaceService<IDbConnectionFactory>((s, k) => new LocalDbConnectionFactory("v11.0"));
                    }
                    else
                    {
                        a.ReplaceService<IDbConnectionFactory>((s, k) => new SqlConnectionFactory());
                    }
                };
            }

            container.RegisterType<SchoolExpressDbContext>(new PerThreadLifetimeManager(),
                new InjectionConstructor(connectionString));
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