using PocketStore.Domain;
using System.Data.Entity;

namespace PocketStore.Infrastructure.DataContexts
{
    public class PocketStoreInitializer : DropCreateDatabaseIfModelChanges<PocketStoreDataContext>
    {
        protected override void Seed(PocketStoreDataContext context)
        {
            context.Categories.Add(new Category { Id = 1, Title = "Bread" });
            context.Categories.Add(new Category { Id = 2, Title = "Drinks" });
            context.Categories.Add(new Category { Id = 3, Title = "Vegetables" });
            context.SaveChanges();
            context.Products.Add(new Product { Id = 1, Title = "Potato", Price = 4 , CategoryId = 3 });
            context.Products.Add(new Product { Id = 2, Title = "Coca-Cola", Price = 11, CategoryId = 2 });
            context.Products.Add(new Product { Id = 3, Title = "Baguette", Price = 1, CategoryId = 3 });
            base.Seed(context);
        }
    }
}
