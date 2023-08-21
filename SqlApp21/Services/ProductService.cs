using Microsoft.Extensions.Configuration;
using SqlApp21.Models;
using System.Data.SqlClient;

namespace SqlApp21.Services
{
    public class ProductService
    {
        private readonly IConfiguration _configuration;

        private static string db_source = "appserver1234563.database.windows.net";
        private static string db_user = "sqladmin";
        private static string db_password = "Azure@123";
        private static string db_database = "appdb";

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;

            return new SqlConnection(_builder.ConnectionString);
            //return new SqlConnection(_configuration.GetConnectionString("SqlConnection"));
        }

        private SqlConnection GetConnection1()
        {
            return new SqlConnection(_configuration.GetConnectionString("SqlConnection"));
        }
        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<Product> productList = new List<Product>();
            string statement = "SELECT ProductID, ProductName, Quantity from Products";
            conn.Open();
            SqlCommand cmd = new SqlCommand(statement, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    productList.Add(product);
                }
            }

            conn.Close();
            return productList;
        }
    }
}
