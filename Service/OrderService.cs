using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Microsoft.Extensions.Logging;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderData _orderData;

        private readonly IProductData _productData;
        private readonly IProductService _productService;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderData orderData, IProductData productData, IProductService productService, ILogger<OrderService> logger)
        {
            this._orderData = orderData;
            this._productData = productData;
            this._productService = productService;
            _logger = logger;
        }
        public async Task<Order> Post(Order order)
        {
            int[] a = new int[] { };
            IEnumerable<Product> products = await _productService.Get(a);
            decimal? sum = 0;
            foreach (var item in order.OrderItems)
            {
                foreach (Product product in products)
                {
                    if (product.Id == item.ProductId)
                    {
                        sum += product.Price * item.Quantity;

                    }

                }
            }
            if (sum != order.TotalPrice)
                _logger.LogInformation(order.UserId + " tryed to steal you! call to police...");
            order.TotalPrice = sum;

            return await this._orderData.Post(order);
        }


    }
}

