using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? TotalPrice { get; set; }
        public virtual User? User { get; set; } = null!;
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
