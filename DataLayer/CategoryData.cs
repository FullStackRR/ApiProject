using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CategoryData : ICategoryData
    {
        _213836612_web_apiContext _dbContext;
        public CategoryData(_213836612_web_apiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Category>> Get()
        {
            var categories = await (from i in _dbContext.Categories
                                    select i).ToListAsync();
            return categories;
        }
    }
}
