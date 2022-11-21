using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Data.Context
{
   public class DapperDbContext
    {
        public SqlConnection SqlConnection()
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            string connectionString = configuration.GetSection("ConnectionStrings").GetSection("connection").Value;
            return new SqlConnection(connectionString);
        }

        public IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            conn.Open();
            return conn;
        }
    }
}
