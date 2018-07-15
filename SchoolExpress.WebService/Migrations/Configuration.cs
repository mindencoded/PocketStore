
namespace SchoolExpress.WebService.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DbContexts.SchoolExpressDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DbContexts.SchoolExpressDbContext context)
        {
            //  This method will be called after migrating to the latest version.
                //context.Set<Course>().AddOrUpdate();
                //  to avoid creating duplicate seed data.
            }
    }
}
