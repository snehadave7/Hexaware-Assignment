using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Dao;
using TechShop.Model;
namespace TechShop.TaskQuestions {
    internal class CollectionsTask {
        private List<Products> products = new List<Products>();
        private List<Orders> orders = new List<Orders>();
        private SortedList<int, Inventory> inventory = new SortedList<int, Inventory>();
        private List<Payments> payments = new List<Payments>();
        private List<OrderDetails> orderDetails = new List<OrderDetails>();


        public void AddProduct(Products product) {
            if (products.Any(p => p.ProductName== product.ProductName)) {
                throw new Exception("Product with the same name already exists.");
            }
            products.Add(product);
        }

        public void UpdateProduct(Products updatedProduct) {
            var product = products.FirstOrDefault(p => p.ProductId == updatedProduct.ProductId);
            if (product == null) {
                throw new Exception("Product not found.");
            }
            product.ProductName = updatedProduct.ProductName;
            product.Category = updatedProduct.Category;
            product.Price = updatedProduct.Price;
        }

        public void RemoveProduct(int productId) {
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null) {
                throw new Exception("Product not found.");
            }
            if (orderDetails.Any(od => od.Product.ProductId == productId)) {
                throw new Exception("Cannot remove product with existing orders.");
            }
            products.Remove(product);
        }

        public void AddOrder(Orders order) {
            orders.Add(order);
        }

        public void UpdateOrderStatus(int orderId, string status) {
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null) {
                throw new Exception("Order not found.");
            }
            order.OrderStatus = status;
        }

        public void RemoveCanceledOrder(int orderId) {
            var order = orders.FirstOrDefault(o => o.OrderId == orderId && o.OrderStatus == "Canceled");
            if (order == null) {
                throw new Exception("Canceled order not found.");
            }
            orders.Remove(order);
        }

        public List<Orders> SortOrdersByDate(bool ascending = true) {
            return ascending ? orders.OrderBy(o => o.OrderDate).ToList() : orders.OrderByDescending(o => o.OrderDate).ToList();
        }

        public void UpdateInventory(int productId, int quantity) {
            if (!inventory.ContainsKey(productId)) {
                throw new Exception("Product not found in inventory.");
            }
            inventory[productId].QuantityInStock -= quantity;
            if (inventory[productId].QuantityInStock < 0) {
                throw new Exception("Insufficient stock.");
            }
        }

        public List<Products> SearchProduct(string searchTerm) {
            return products.Where(p => p.ProductName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                       p.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void RecordPayment(Payments payment) {
            payments.Add(payment);
        }

        public void UpdatePaymentStatus(int paymentId, string status) {
            var payment = payments.FirstOrDefault(p => p.PaymentId == paymentId);
            if (payment == null) {
                throw new Exception("Payment not found.");
            }
            payment.Status = status;
        }
    }
}
