using System;

namespace PocketStore.Domain
{
    public class Product
    {
        public Product()
        {
            AcquireDate = DateTime.Now;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime AcquireDate { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
