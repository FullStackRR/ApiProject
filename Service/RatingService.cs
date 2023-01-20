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
        public void SaveDetails(Rating rating)
        {
            _ratingData.save(rating);
        }
    }
}
