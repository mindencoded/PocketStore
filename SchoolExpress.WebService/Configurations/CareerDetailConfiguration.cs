using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class CareerDetailConfiguration : EntityTypeConfiguration<CareerDetail>
    {
        public CareerDetailConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasIndex(x => new {x.CareerId, x.CourseId}).IsUnique();
        }
    }
}