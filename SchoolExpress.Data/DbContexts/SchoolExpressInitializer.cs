using System.Data.Entity;

namespace SchoolExpress.Data.DbContexts
{
    public class SchoolExpressInitializer : DropCreateDatabaseIfModelChanges<SchoolExpressDbContext>
    {
        protected override void Seed(SchoolExpressDbContext context)
        {
            base.Seed(context);
        }
    }
}