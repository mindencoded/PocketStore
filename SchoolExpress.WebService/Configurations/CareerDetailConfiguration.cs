using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class CareerDetailConfiguration : EntityTypeConfiguration<CareerDetail>
    {
        public CareerDetailConfiguration()
        {
            HasIndex(x => new {x.CareerId, x.CourseId}).IsUnique();
        }
    }
}