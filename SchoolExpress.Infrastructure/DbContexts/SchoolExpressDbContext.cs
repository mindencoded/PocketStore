using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SchoolExpress.Infrastructure.Configurations;

namespace SchoolExpress.Infrastructure.DbContexts
{
    public class SchoolExpressDbContext : DbContext
    {
        public SchoolExpressDbContext() : base("SchoolExpressConnection")
        {
            //Configuration.ValidateOnSaveEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            //Database.SetInitializer(new SchoolExpressInitializer());
        }
        public IDbSet<T> DbSet<T>() where T : class 
        {
                return Set<T>(); 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new EnrollmentConfiguration());
            modelBuilder.Configurations.Add(new EnrollmentDetailConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new ScheduleConfiguration());
            modelBuilder.Configurations.Add(new ScheduleDetailConfiguration());
            modelBuilder.Configurations.Add(new AssignmentConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new ClassRoomConfiguration());
            modelBuilder.Configurations.Add(new AcademicTermConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new GradeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}