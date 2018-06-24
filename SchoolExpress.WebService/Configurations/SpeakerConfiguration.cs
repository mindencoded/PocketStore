using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class SpeakerConfiguration : EntityTypeConfiguration<Speaker>
    {
        public SpeakerConfiguration()
        {
            Property(x => x.Achievements).HasMaxLength(500);
        }
    }
}