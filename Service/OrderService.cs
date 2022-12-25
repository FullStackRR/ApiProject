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
        public async Task Post(Order order)
        {
           await this._data.Post(order);
        }

        
    }
}
