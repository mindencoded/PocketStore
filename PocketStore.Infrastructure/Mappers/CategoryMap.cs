using PocketStore.Domain;
using System.Data.Entity.ModelConfiguration;

namespace PocketStore.Infrastructure.Mappers
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Title).HasMaxLength(60);
        }
    }
}
