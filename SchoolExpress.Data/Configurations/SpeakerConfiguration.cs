using System.Data.Entity.ModelConfiguration;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Configurations
{
    public class SpeakerConfiguration : EntityTypeConfiguration<Speaker>
    {
        public SpeakerConfiguration()
        {
            Property(x => x.Achievements).HasMaxLength(500);
        }
    }
}