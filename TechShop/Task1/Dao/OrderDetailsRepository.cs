using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;
using TechShop.Util;

namespace TechShop.Dao {
    internal class OrderDetailsRepository : IOrderDetails {
        public void AddDiscount() {
            throw new NotImplementedException();
        }

        public void AddOrderDetails(DBConnection dbConnection,OrderDetails orderDetail) {
            string query = "INSERT INTO orderDetails (orderId,productId,quantity) " +
                           "VALUES (@orderId,@productId,@quantity)";

            SqlConnection connection = dbConnection.connection;
            using (SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.AddWithValue("@orderId", orderDetail.Order.OrderId);
                command.Parameters.AddWithValue("@productId", orderDetail.Product.ProductId);
                command.Parameters.AddWithValue("@quantity", orderDetail.Quantity);
                command.ExecuteNonQuery();
                
            }
        }

 

        public void CalculateSubTotal() {
            throw new NotImplementedException();
        }

        public void GetOrderDetailInfo() {
            throw new NotImplementedException();
        }

        public void UpdateQuantity() {
            throw new NotImplementedException();
        }
    }
}
