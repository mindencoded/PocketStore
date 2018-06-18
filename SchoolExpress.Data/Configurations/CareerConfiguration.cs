using System.Data.Entity.ModelConfiguration;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Configurations
{
    public class CareerConfiguration : EntityTypeConfiguration<Career>
    {
        public CareerConfiguration()
        {
            HasIndex(x => new { x.Description }).IsUnique();
            Property(x => x.Description).IsRequired();
        }
    }
}