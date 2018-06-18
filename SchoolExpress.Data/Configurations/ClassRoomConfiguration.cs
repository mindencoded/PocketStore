using System.Data.Entity.ModelConfiguration;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Configurations
{
    public class ClassRoomConfiguration : EntityTypeConfiguration<ClassRoom>
    {
        public ClassRoomConfiguration()
        {
            HasIndex(x => new { x.Description }).IsUnique();
            Property(x => x.Description).IsRequired();
        }
    }
}