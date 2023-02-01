using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Entity;
using Service;

namespace ApiProject.Middlware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRatingService _ratingService;
        public RatingMiddleware(RequestDelegate next ,IRatingService r)
        {
            _ratingService = r;
            _next = next;
        }
        
        public Task Invoke(HttpContext httpContext )
        {
            string method = httpContext.Request.Method;
            string host = httpContext.Request.Host.ToString();
            string path = httpContext.Request.Path;
            string referer = httpContext.Request.Headers["Referer"];
            string userAgent = httpContext.Request.Headers["User-Agent"];
            DateTime recordDate = DateTime.Now;

            //string referer = httpContext.Request.;
            Rating rating = new Rating() { Method = method, Host = host, Path = path,RecordDate=recordDate, UserAgent =userAgent, Referer = referer,  };
            _ratingService.SaveDetails(rating);

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingExtensions
    {
        public static IApplicationBuilder UseRating(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
