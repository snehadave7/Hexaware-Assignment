using System;
using TechShop.Model;
using TechShop.Util;
namespace TechShop.Dao {
    internal interface IOrderDetails {
        public void CalculateSubTotal();
        public void GetOrderDetailInfo();
        public void AddOrderDetails(DBConnection dbConnection, OrderDetails orderDetail);
        public void UpdateQuantity();
        public void AddDiscount();
    }
}
