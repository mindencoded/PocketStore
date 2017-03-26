using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.Practices.Unity;
using SchoolExpress.Infrastructure.Contracts;
using SchoolExpress.Infrastructure.Helpers;
using SchoolExpress.Infrastructure.Uows;

namespace SchoolExpress.WebService
{
    public static class UnityConfig
    {
        public static IUnityContainer GetConfiguredContainer()
        {
            var container = new UnityContainer();
            container.RegisterType(
                typeof(IDictionary<Type, Func<DbContext, object>>),
                typeof(Dictionary<Type, Func<DbContext, object>>),
                new InjectionConstructor());
            container.RegisterType<ISchoolExpressUow, SchoolExpressUow>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryProvider, RepositoryProvider>(new HierarchicalLifetimeManager());
            return container;
        }
    }
}