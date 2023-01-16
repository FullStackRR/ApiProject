using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace ApiProject.Middlware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Rating
    {
        private readonly RequestDelegate _next;

        public Rating(RequestDelegate next )
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext ,IConfiguration config)
        {
            string method = httpContext.Request.Method;
            string host = httpContext.Request.Host.ToString();
            string path = httpContext.Request.Path;
            //DateTime recordDate = new DateTime().;
            //string referer = httpContext.Request.;
            string _connctionString = config.GetValue<string>("ConnectionString");

            string queary = "insert into RATING (METHOD ,HOST ,PATH ) values(@method, @host, @path) ";
            using (SqlConnection connection = new SqlConnection(_connctionString))
            using (SqlCommand command = new SqlCommand(queary, connection))
            {
                //command.Parameters.Add("@date", SqlDbType.DateTime);
                //command.Parameters["@date"].Value = recordDate;
                command.Parameters.Add("@method", SqlDbType.NChar);
                command.Parameters["@method"].Value = method;
                command.Parameters.Add("@host", SqlDbType.NVarChar);
                command.Parameters["@host"].Value = host;
                command.Parameters.Add("@path", SqlDbType.NVarChar);
                command.Parameters["@path"].Value = path;
                //command.Parameters.Add("@referer", SqlDbType.NVarChar);
                //command.Parameters["@referer"].Value = referer;
                //command.Parameters.Add("@date", SqlDbType.NVarChar);
                //command.Parameters["@date"].Value = recordDate;

                command.Connection.Open();
                command.ExecuteNonQuery();

            }


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
