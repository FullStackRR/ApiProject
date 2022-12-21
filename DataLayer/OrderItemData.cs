using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OrderItemData : IOrderItemData
    {
        _213836612_web_apiContext _dbContext;
        public OrderItemData(_213836612_web_apiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Post(OrderItem item)
        {
            await _dbContext.OrderItems.AddAsync(item);
            _dbContext.SaveChangesAsync();


        }
    }
}
