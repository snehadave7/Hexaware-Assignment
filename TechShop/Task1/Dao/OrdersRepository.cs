using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;
using TechShop.Util;


namespace TechShop.Dao {
    internal class OrdersRepository : IOrders {
        public void AddOrders(DBConnection dbConnection, Orders order) {
            string orderStatus = "PlacedOrder";
            SqlConnection connection = dbConnection.connection;
            string query = "SET IDENTITY_INSERT Orders ON " +
                "insert into Orders(orderId,customerId,OrderDate,TotalAmount,OrderStatus)" +
                           "values(@orderId,@customerId,@dateTime,@totalAmount,@orderStatus)";

            using (SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.AddWithValue("@orderId",order.OrderId);
                command.Parameters.AddWithValue("@customerId",order.Customer.CustomerId);
                command.Parameters.AddWithValue("@dateTime",order.OrderDate);
                command.Parameters.AddWithValue("@totalAmount",order.TotalAmount);
                command.Parameters.AddWithValue("@orderStatus",orderStatus);
                command.ExecuteNonQuery();
            }


        }
        
        public int GetOrderId(DBConnection dbConnection) { 
            SqlConnection connection=dbConnection.connection;
            string query = $"select top 1 orderId from orders order by orderId desc";
            using (SqlCommand command = new SqlCommand(query, connection)) {

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        return reader.GetInt32(0)+1;
                    }
                    return 0;
                }
            }
        }


        public decimal CalculateTotalAmount(DBConnection dBConnection,int quantity,int productId) {
            SqlConnection connection = dBConnection.connection;
            string query=$"select price from products where productid={productId}";
            using (SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.AddWithValue("@ProductId", productId);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        return reader.GetInt32(0)*quantity;
                    }
                    else return 0;
                }
            }


        }
        public void CalculateTotalSales(DBConnection dBConnection) {
            SqlConnection connection = dBConnection.connection;
            string query = "SELECT SUM(TotalAmount) AS TotalSales FROM orders";
            using (SqlCommand command = new SqlCommand(query, connection)) {
                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        Console.WriteLine(reader["TotalSales"].ToString()); // Access by alias
                    }
                }
            }
        }


        public void CheckStatus(DBConnection dBConnection, int orderId) {

            SqlConnection connection = dBConnection.connection;
            string query = "select orderStatus from orders where orderid=@orderId";

            using (SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.AddWithValue("@orderId", orderId);

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        Console.WriteLine(reader["orderStatus"].ToString());
                    }
                }
            }
        }
        public void CancelOrder() {
            throw new NotImplementedException();
        }

        public void GetOrderDetails() {
            throw new NotImplementedException();
        }

        public void UpdateOrderStatus() {
            throw new NotImplementedException();
        }
    }
}
