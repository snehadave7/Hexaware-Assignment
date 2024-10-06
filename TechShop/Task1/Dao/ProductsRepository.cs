using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;
using TechShop.Util;

namespace TechShop.Dao {
    internal class ProductsRepository : IProducts {

        public void GetProductDetails(DBConnection dbconnection) {
            SqlConnection connection=dbconnection.connection;
            string query = "SELECT * FROM products";
            using (SqlCommand selectCommand = new SqlCommand(query, connection)) {
                using (SqlDataReader reader = selectCommand.ExecuteReader()) {
                    while (reader.Read()) {
                        Console.WriteLine($"ProductID: {reader["productId"]} , ProductName: {reader["productName"]} , Description: {reader["description"]} , Price: {reader["price"]}, Category: {reader["Category"]}");
                    }
                }
            }
        }

        public void GetProductDetails(DbConnection connection) {
            throw new NotImplementedException();
        }

        public Products GetSingleProductDetails(DBConnection dBConnection,int productId) {
            SqlConnection connection = dBConnection.connection;
            string query = $"SELECT * FROM Products where productId={productId}";
            using (SqlCommand selectCommand = new SqlCommand(query, connection)) {
                using (SqlDataReader reader = selectCommand.ExecuteReader()) {

                    if (reader.Read()) {
                        int ProductId = reader.GetInt32(0);
                        string productName = reader["productName"].ToString();
                        string description = reader["description"].ToString();
                        int price = reader.GetInt32(3);
                        string category=reader["category"].ToString();
                        Products product = new Products(productName,description,price,category);
                        return product;
                    }
                    return null;

                }
            }
        }

        public void SearchByCategory(DBConnection dbconnection, string category) {

            SqlConnection connection = dbconnection.connection;
            string query = "select * from products where category=@category";

            using (SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.AddWithValue("@category", category);

                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Console.WriteLine($"ProductId: {reader["productId"].ToString()} ProductName: {reader["productName"].ToString()} ProductPrice: {reader["price"].ToString()}");

                    }
                }
            }

        }


        //public bool IsProductInStock(DBConnection dBConnection,int productId) {
        //    SqlConnection connection= dBConnection.connection;
        //    string query = $"select quantityInStock from Inventory where productId={productId}";
        //    using (SqlCommand selectCommand = new SqlCommand(query, connection)) {
        //        using (SqlDataReader reader = selectCommand.ExecuteReader()) {
        //            if (reader.Read()) {
        //                if (reader["quantityInStock"].Equals(0)) {
        //                    return false;
        //                }
        //                else return true;
        //            }
        //            else return false;
        //        }
        //    }
        //}

        public void AddProduct(DBConnection dbconnection,Products product) {
            string query = "INSERT INTO Products (ProductName,description,Price,Category) " +
                           "VALUES (@ProductName,@description,@Price,@Category)";



            SqlConnection connection = dbconnection.connection;
            using (SqlCommand command = new SqlCommand(query, connection)) {
                
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Category",product.Category);
              
                command.ExecuteNonQuery();
                Console.WriteLine("Product Added Successfully...");
            }

        }



        public void UpdateProductInfo() {
            throw new NotImplementedException();
        }
    }
}
