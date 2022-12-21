using System;
using System.Collections.Generic;

namespace DataLayer
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual User? User { get; set; } = null!;
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
