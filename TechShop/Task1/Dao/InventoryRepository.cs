using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;
using TechShop.Util;

namespace TechShop.Dao {
    internal class InventoryRepository : IInventory {
        public void AddToInventory(int quantity) {
            throw new NotImplementedException();
        }

        public void GetInventoryValue() {
            throw new NotImplementedException();
        }

        public void GetProduct() {
            throw new NotImplementedException();
        }

        public int GetQuantityInStock(DBConnection dBConnection, int productId) {
            SqlConnection connection = dBConnection.connection;
            string query = $"select quantityInStock from Inventory where productId={productId}";
            using (SqlCommand selectCommand = new SqlCommand(query, connection)) {
                using (SqlDataReader reader = selectCommand.ExecuteReader()) {
                    if (reader.Read()) {
                        return reader.GetInt32(0);
                    }
                    else return 0;
                       

                }
            }
        }

        

        public bool isProductInStock(DBConnection dBConnection, int productId) {
            SqlConnection connection = dBConnection.connection;
            string query = $"select quantityInStock from Inventory where productId={productId}";
            using (SqlCommand selectCommand = new SqlCommand(query, connection)) {
                using (SqlDataReader reader = selectCommand.ExecuteReader()) {
                    if (reader.Read()) {
                        if (reader["quantityInStock"].Equals(0)) {
                            return false;
                        }
                        else return true;
                    }
                    else return false;
                }
            }
        }

      
        public void ListAllProducts() {
            throw new NotImplementedException();
        }

        public void ListLowStockProducts(int threshold) {
            throw new NotImplementedException();
        }

        public void ListOutOfStockProducts() {
            throw new NotImplementedException();
        }

        public void RemoveFromInventory(int quantity) {
            throw new NotImplementedException();
        }

        public void UpdateStockQuantity(DBConnection dBConnection, int newQuantity, int productId) {
            string query = "UPDATE Inventory SET QuantityInStock = QuantityInStock - @newQuantity WHERE productId = @productId";

            SqlConnection connection = dBConnection.connection;
            using (SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.AddWithValue("@newQuantity", newQuantity);
                command.Parameters.AddWithValue("@productId", productId);
                command.ExecuteNonQuery();
            }
        }
        public void UpdateStock(DBConnection dBConnection, int newQuantity, int productId) {
            string query = "UPDATE Inventory SET QuantityInStock =@newQuantity WHERE productId = @productId";

            SqlConnection connection = dBConnection.connection;
            using (SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.AddWithValue("@newQuantity", newQuantity);
                command.Parameters.AddWithValue("@productId", productId);
                command.ExecuteNonQuery();
            }
        }
        public void DiscontinueItem(DBConnection dBConnection) {
            string query = $"DELETE FROM Inventory  WHERE QuantityInStock={0}";

            SqlConnection connection = dBConnection.connection;
            using (SqlCommand command = new SqlCommand(query, connection)) {
                command.ExecuteNonQuery();
            }
        }
    }
}
