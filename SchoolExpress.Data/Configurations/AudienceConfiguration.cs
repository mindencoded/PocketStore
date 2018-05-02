using System.Data.Entity.ModelConfiguration;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Configurations
{
    public class AudienceConfiguration : EntityTypeConfiguration<Audience>
    {
        public AudienceConfiguration()
        {
            HasKey(x => x.ClientId);
            Property(x => x.ClientId).HasMaxLength(36);
        }
    }
}