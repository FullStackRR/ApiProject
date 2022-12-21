using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemData _data;

        public OrderItemService(IOrderItemData data)
        {
            this._data = data;
        }
        public async Task Post(OrderItem orderItem)
        {
            await _data.Post(orderItem);

        }
    }
}
