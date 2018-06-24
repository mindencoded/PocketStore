using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class CareerConfiguration : EntityTypeConfiguration<Career>
    {
        public CareerConfiguration()
        {
            HasIndex(x => new {x.Description}).IsUnique();
            Property(x => x.Description).IsRequired();
        }
    }
}