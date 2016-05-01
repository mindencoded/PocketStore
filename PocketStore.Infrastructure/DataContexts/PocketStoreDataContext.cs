using PocketStore.Domain;
using PocketStore.Infrastructure.Mappers;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PocketStore.Infrastructure.DataContexts
{
    public class PocketStoreDataContext : DbContext
    {
        public PocketStoreDataContext() : base("PocketStoreConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            //Database.SetInitializer(new PocketStoreInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
