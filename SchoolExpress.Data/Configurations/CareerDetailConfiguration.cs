using System.Data.Entity.ModelConfiguration;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Configurations
{
    public class CareerDetailConfiguration : EntityTypeConfiguration<CareerDetail>
    {
        public CareerDetailConfiguration()
        {
            HasIndex(x => new {x.CareerId, x.CourseId}).IsUnique();
        }
    }
}