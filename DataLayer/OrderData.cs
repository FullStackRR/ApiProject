using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OrderData : IOrderData
    {
        _213836612_web_apiContext _dbContext;
        public OrderData(_213836612_web_apiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Order> Post(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }
    }
}
