using System;

using System.Data.SqlClient;
namespace TechShop.Util {
    internal class DBConnection:IDisposable {
        public SqlConnection connection;
        public SqlCommand command;

        public DBConnection() {
            string connectionString = DBProperty.GetProperty();
            connection=new SqlConnection(connectionString);
            connection.Open();
            command=connection.CreateCommand();

        }

        public void Close() {
            command?.Dispose();
            connection?.Close();
        }
        public void Dispose() {
            Close();
            GC.SuppressFinalize(this);
        }

        public bool TestConnection() {
            return connection.State == System.Data.ConnectionState.Open;
        }
        
    }
}


  