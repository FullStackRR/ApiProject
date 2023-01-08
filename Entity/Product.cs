using System;
using System.Collections.Generic;

namespace DataLayer
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? ImgUrl { get; set; }
        public int? GuarantyMonth { get; set; }
        public string? CountryOfProduction { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
