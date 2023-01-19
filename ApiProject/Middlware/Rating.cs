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
    public class Rating
    {
        private readonly RequestDelegate _next;
        private readonly IRatingService _ratingService;
        public Rating(RequestDelegate next ,IRatingService r)
        {
            _ratingService = r;
            _next = next;
        }
        
        public Task Invoke(HttpContext httpContext )
        {
            string method = httpContext.Request.Method;
            string host = httpContext.Request.Host.ToString();
            string path = httpContext.Request.Path;
            //DateTime recordDate = new DateTime().;
            //string referer = httpContext.Request.;
            //Rating rating = new Rating() { };//כנראה אי אפשר ליצור כזה אוביקט במידל...
            _ratingService.SaveDetails(method,host, path);

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingExtensions
    {
        public static IApplicationBuilder UseRating(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Rating>();
        }
    }
}
