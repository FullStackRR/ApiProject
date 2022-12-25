using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProductData : IProductData
    {
        _213836612_web_apiContext _dbContext;
        public ProductData(_213836612_web_apiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Product>> Get(int[]? categoryId, string? dir = "asc", int? fromPrice = null, int? toPrice = null, string? description = null)
        {
            var query = _dbContext.Products.Where(product =>
          (description == null ? (true) : (product.Name.Contains(description)))
          && (fromPrice == null ? (true) : (product.Price >= fromPrice))
          && (toPrice == null ? (true) : (product.Price<= toPrice))
          && ((categoryId.Length==0) ? (true) : (categoryId.Contains(product.CategoryId))))
                .OrderBy(product=>product.Price);
            List<Product> products = await query.ToListAsync();
            return products;
        }
    }
}
