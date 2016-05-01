using System.Collections.Generic;

namespace PocketStore.Domain
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}