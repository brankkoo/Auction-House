using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse.Model
{
    public class ProductCollection : ObservableCollection<Product>
    {
        public static ProductCollection GetProducts()
        {
            ProductCollection products = new ProductCollection();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["masterDatabase"].ToString();
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Product", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product((string)reader["Name"], (double)reader["Price"],  (double)reader["LastOffer"], (string)reader["LastBidder"],(int)reader["Time"],(int)reader["ID"]);
                        products.Add(product);
                    }
                }
                return products;
            }
        }


    }
}
