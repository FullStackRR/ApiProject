using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderData _data;

        public OrderService(IOrderData data)
        {
            this._data = data;
        }
        public Task<Order> Post(Order order)
        {
            return this._data.Post(order);
        }
    }
}
