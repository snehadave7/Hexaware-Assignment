
using System.Collections.Generic;
using System.Data.SqlClient;
using TechShop.Model;
using TechShop.Util;

namespace TechShop.Dao {
    internal class CustomerRepository : ICustomers {
        public bool CheckExistingEmail(DBConnection dbconnection, string email) {
            string query = "SELECT email from Customers where email=@email";

            SqlConnection connection = dbconnection.connection;
            using (SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.AddWithValue("@email", email);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    return reader.Read();
                }
            }
        }

        public void CalculateTotalOrders() {
            throw new NotImplementedException();
        }



        public void CreateNewCustomer(DBConnection dbconnection, Customers customer) {

            string query = " SET IDENTITY_INSERT Customers ON " +
                            "INSERT INTO Customers (customerId,firstName,lastName,email,phone,address) " +
                           "VALUES (@customerId,@firstName,@lastName,@email,@phone,@address)";



            SqlConnection connection = dbconnection.connection;
            using (SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.AddWithValue("@customerId", customer.CustomerId);
                command.Parameters.AddWithValue("@firstName", customer.FirstName);
                command.Parameters.AddWithValue("@lastName", customer.LastName);
                command.Parameters.AddWithValue("@email", customer.Email);
                command.Parameters.AddWithValue("@phone", customer.Phone);
                command.Parameters.AddWithValue("@address", customer.Address);
                command.ExecuteNonQuery();
                Console.WriteLine("Customer Added Successfully...");
            }
        }

        public Customers GetCustomerDetails(DBConnection dBConnection, string email) {
            SqlConnection connection = dBConnection.connection;
            string query = $"SELECT * FROM customers where email='{email}'";
            using (SqlCommand selectCommand = new SqlCommand(query, connection)) {
                using (SqlDataReader reader = selectCommand.ExecuteReader()) {

                    if (reader.Read()) {
                        int customerId = reader.GetInt32(0);
                        string firtName = reader["firstName"].ToString();
                        string lastName = reader["lastName"].ToString();
                        string Email = reader["email"].ToString();
                        string phone = reader["phone"].ToString();
                        string address = reader["address"].ToString();
                        Customers customer = new Customers(customerId, firtName, lastName, Email, phone, address);
                        return customer;
                    }
                    return null;

                }
            }
        }
        public int GetCustomerId(DBConnection dbConnection, string email) {
            SqlConnection connection = dbConnection.connection;
            string query = "SELECT customerId FROM customers WHERE email = @Email";
            using (SqlCommand command = new SqlCommand(query, connection)) {
                command.Parameters.AddWithValue("@Email", email);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        return reader.GetInt32(0);
                    }
                    else return 0;
                }
            }
        }
        public int GetNewCustomerId(DBConnection dbConnection) {
            SqlConnection connection = dbConnection.connection;
            string query = $"select top 1 customerId from customers order by customerId desc";
            using (SqlCommand command = new SqlCommand(query, connection)) {

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        return reader.GetInt32(0) + 1;
                    }
                    return 0;
                }
            }
        }

        public void UpdateCustomerInfo(string contact, int customerId, DBConnection dBConnection) {
            string query = $"UPDATE Customers SET Contact={contact} WHERE CustomerId={customerId}";
            using (SqlConnection connection = new SqlConnection()) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

   


       
