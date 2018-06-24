using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            HasIndex(x => new {x.SubscriptionId}).IsUnique();
            Property(x => x.SubscriptionId).IsRequired();
        }
    }
}