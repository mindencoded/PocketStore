using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            HasIndex(x => new {x.Description}).IsUnique();
            Property(x => x.Description).IsRequired();
        }
    }
}