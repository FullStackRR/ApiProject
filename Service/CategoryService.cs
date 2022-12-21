using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryData _data;

        public CategoryService(ICategoryData data)
        {
            this._data = data;
        }
        public async Task<IEnumerable<Category>> Get()
        {
            IEnumerable<Category> i= await _data.Get();
            return i;
           
        }

    }
}
