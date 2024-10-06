using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Dao;
namespace TechShop.Model {
    internal class Orders{
        int orderId;
        Customers customer;
        DateTime orderDate;
        decimal totalAmount;
        string orderStatus;
        public Orders(int orderId, DateTime orderDate, decimal totalAmount, Customers customer) {
            this.orderId = orderId;
            this.orderDate = orderDate;
            this.totalAmount = totalAmount;
            this.customer = customer;
        }
        public Orders(int orderId, DateTime orderDate, decimal totalAmount)
        {
            this.orderId = orderId;
            this.orderDate = orderDate;
            this.totalAmount = totalAmount;

        }
        public Orders()
        {
            
        }
        public int OrderId {
            get { return orderId; }
            set { orderId = value; }
        }

        public DateTime OrderDate {
            get { return orderDate; }
            set { orderDate = value; }
        }

        public decimal TotalAmount {
            get { return totalAmount; }
            set { totalAmount = value; }
        }

        public Customers Customer{
            get { return customer; }
            set { customer = value; }
        }

        public string OrderStatus {
            get { return orderStatus; }
            set { orderStatus = value; }
        }
        public override string ToString() {
            return $"OrderId: {orderId} OrderDate: {orderDate} TotalAmount: {totalAmount} Customer: {customer.Email} OrderStatus: {orderStatus}";
        }



    }
}
