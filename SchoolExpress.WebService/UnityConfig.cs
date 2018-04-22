using SchoolExpress.Infrastructure.DbContexts;
using SchoolExpress.Infrastructure.Uows;
using Unity;
using Unity.Injection;

namespace SchoolExpress.WebService
{
    public static class UnityConfig
    {
        public static IUnityContainer GetConfiguredContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<ISchoolExpressUow, SchoolExpressUow>(
                new InjectionConstructor(new SchoolExpressDbContext()));
            return container;
        }
    }
}