using PocketStore.Domain;
using System.Data.Entity.ModelConfiguration;

namespace PocketStore.Infrastructure.Mappers
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Title).HasMaxLength(120).IsRequired();
            Property(x => x.Description).HasMaxLength(260).IsOptional();
            Property(x => x.Price).IsRequired();
            Property(x => x.AcquireDate).IsRequired();
            HasRequired(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        }
    }
}
