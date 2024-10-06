using System;
using TechShop.Model;
using TechShop.Util;
namespace TechShop.Dao {
    internal interface ICustomers {
        public bool CheckExistingEmail(DBConnection dbconnection,string email);
        public void CalculateTotalOrders();
        public void CreateNewCustomer(DBConnection dbconnection, Customers customer);
        public void UpdateCustomerInfo(string contact, int customerId, DBConnection dBConnection);
        public int GetCustomerId(DBConnection dbConnection, string email);
        public Customers GetCustomerDetails(DBConnection dBConnection, string email);
    }
}
