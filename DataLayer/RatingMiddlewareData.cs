using Entity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class RatingMiddlewareData : IRatingMiddlewareData
    {
        private readonly IConfiguration config;
        public RatingMiddlewareData(IConfiguration config)
        {

            this.config = config;
        }
        public void save(Rating rating)
        {
            
            int i = 0;
            /////////////////////////////////////////////////////////// להוסיף 'rating.'
            // string _connctionString = this.config.GetValue<string>("ConnectionString");
            //string _connctionString = this.config.GetConnectionString("school");
            //string queary = "insert into RATING (METHOD ,HOST ,PATH ) values(@method, @host, @path) ";
            //using (SqlConnection connection = new SqlConnection(_connctionString))
            //using (SqlCommand command = new SqlCommand(queary, connection))
            //{
            //    //command.Parameters.Add("@date", SqlDbType.DateTime);
            //    //command.Parameters["@date"].Value = rating.recordDate; 
            //    command.Parameters.Add("@method", SqlDbType.NChar);
            //    command.Parameters["@method"].Value = method;
            //    command.Parameters.Add("@host", SqlDbType.NVarChar);
            //    command.Parameters["@host"].Value = host;
            //    command.Parameters.Add("@path", SqlDbType.NVarChar);
            //    command.Parameters["@path"].Value = path;
            //    //command.Parameters.Add("@referer", SqlDbType.NVarChar);
            //    //command.Parameters["@referer"].Value = referer;
            //    //command.Parameters.Add("@date", SqlDbType.NVarChar);
            //    //command.Parameters["@date"].Value = recordDate;

            //    command.Connection.Open();
            //    command.ExecuteNonQuery();
        }
    }

}

