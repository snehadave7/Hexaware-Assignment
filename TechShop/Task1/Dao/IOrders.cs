using System;
using TechShop.Model;
using TechShop.Util;

namespace TechShop.Dao {
    internal interface IOrders {
        public decimal CalculateTotalAmount(DBConnection dBConnection,int quantity,int productId);
        public void GetOrderDetails();
        public void UpdateOrderStatus();
        public void CancelOrder();

        public void AddOrders(DBConnection dBConnection,Orders order);
    }
}
