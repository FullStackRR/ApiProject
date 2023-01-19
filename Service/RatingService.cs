using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Service
{
    public class RatingService : IRatingService
    {
        private readonly IRatingMiddlewareData _ratingData;
        public RatingService(IRatingMiddlewareData r)
        {
            _ratingData = r;
        }
        public void SaveDetails(string method, string host, string path)
        {
            Rating rating = new Rating() { Method = method, Host = host, Path = path };
            _ratingData.save(rating);
        }
    }
}
