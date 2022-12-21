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
        public async Task<IEnumerable<Product>> Get()
        {
            return null;
        }
    }
}
