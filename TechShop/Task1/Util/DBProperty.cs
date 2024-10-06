using System;
using TechShop.Dao;
using TechShop.Model;
using System.Data.SqlClient;
namespace TechShop.Util {
    internal class DBProperty {

        public static string GetProperty() {
            string serverName = @"LAPTOP-NU6C09HU";
            string databaseName = "TechShop";

            string connectionString=$"Server={serverName}; Database={databaseName}; Integrated Security=True;";
            return connectionString;
        }
        
    }
}

