using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IProductData _data;

        public ProductService(IProductData data)
        {
            this._data = data;
        }
        public async Task<IEnumerable<Product>> Get( int[]? categoryId, string? dir = "asc",int? fromPrice = null, int? toPrice = null,string? description = null)
        {
            return await _data.Get( categoryId, dir ,  fromPrice, toPrice, description);
        }
    }
}
