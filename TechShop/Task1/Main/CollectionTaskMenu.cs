using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Dao;
using TechShop.Exceptions;
using TechShop.Model;
using TechShop.TaskQuestions;

namespace TechShop.Main {
    internal class CollectionTaskMenu {
        CollectionsTask task = new CollectionsTask();
        
        public void CollectionTaskRun() {
            bool exit = false;

            while (!exit) {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Remove Product");
                Console.WriteLine("4. Add Order");
                Console.WriteLine("5. Update Order Status");
                Console.WriteLine("6. Remove Canceled Order");
                Console.WriteLine("7. Sort Orders by Date");
                Console.WriteLine("8. Update Inventory");
                Console.WriteLine("9. Search Product");
                Console.WriteLine("10. Record Payment");
                Console.WriteLine("11. Update Payment Status");
                Console.WriteLine("0. Exit");

                int choice = int.Parse(Console.ReadLine());

                try {
                    switch (choice) {
                        case 1:
                            
                            Console.WriteLine("Enter Product ID:");
                            int productId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Product Name:");
                            string productName = Console.ReadLine();
                            Console.WriteLine("Enter Category:");
                            string category = Console.ReadLine();
                            Console.WriteLine("Enter Price:");
                            int stock = int.Parse(Console.ReadLine());

                            task.AddProduct(new Products { ProductId = productId, ProductName = productName, Category = category, Price = stock });
                            Console.WriteLine("Product added successfully.");
                            break;

                        case 2:
                           
                            Console.WriteLine("Enter Product ID to Update:");
                            productId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter New Product Name:");
                            productName = Console.ReadLine();
                            Console.WriteLine("Enter New Category:");
                            category = Console.ReadLine();
                            Console.WriteLine("Enter New Price:");
                            stock = int.Parse(Console.ReadLine());

                            task.UpdateProduct(new Products { ProductId = productId, ProductName = productName, Category = category, Price = stock });
                            Console.WriteLine("Product updated successfully.");
                            break;

                        case 3:
                            
                            Console.WriteLine("Enter Product ID to Remove:");
                            productId = int.Parse(Console.ReadLine());

                            task.RemoveProduct(productId);
                            Console.WriteLine("Product removed successfully.");
                            break;

                        case 4:
                            
                            Console.WriteLine("Enter Order ID:");
                            int orderId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Order Date (yyyy-mm-dd):");
                            DateTime orderDate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Status:");
                            string status = Console.ReadLine();

                            task.AddOrder(new Orders { OrderId = orderId, OrderDate = orderDate, OrderStatus = status });
                            Console.WriteLine("Order added successfully.");
                            break;

                        case 5:
                            
                            Console.WriteLine("Enter Order ID to Update:");
                            orderId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter New Status:");
                            status = Console.ReadLine();

                            task.UpdateOrderStatus(orderId, status);
                            Console.WriteLine("Order status updated successfully.");
                            break;

                        case 6:
                            
                            Console.WriteLine("Enter Order ID to Remove (Canceled orders only):");
                            orderId = int.Parse(Console.ReadLine());

                            task.RemoveCanceledOrder(orderId);
                            Console.WriteLine("Canceled order removed successfully.");
                            break;

                        case 7:
                            
                            Console.WriteLine("Sort by Ascending (A) or Descending (D)?");
                            string sortOrder = Console.ReadLine();
                            bool ascending = sortOrder.ToUpper() == "A";

                            var sortedOrders = task.SortOrdersByDate(ascending);
                            Console.WriteLine("Orders sorted successfully.");
                            foreach (var order in sortedOrders) {
                                Console.WriteLine($"Order ID: {order.OrderId}, Date: {order.OrderDate}, Status: {order.OrderStatus}");
                            }
                            break;

                        case 8:
                           
                            Console.WriteLine("Enter Product ID for Inventory Update:");
                            productId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Quantity to Decrease:");
                            int quantity = int.Parse(Console.ReadLine());

                            task.UpdateInventory(productId, quantity);
                            Console.WriteLine("Inventory updated successfully.");
                            break;

                        case 9:
                            
                            Console.WriteLine("Enter Product Name or Category to Search:");
                            string searchTerm = Console.ReadLine();

                            var searchResults = task.SearchProduct(searchTerm);
                            Console.WriteLine("Search results:");
                            foreach (var product in searchResults) {
                                Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.ProductName}, Category: {product.Category}, Stock: {product.Price}");
                            }
                            break;

                        case 10:
                            
                            Console.WriteLine("Enter Payment ID:");
                            int paymentId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Order ID for Payment:");
                            orderId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Payment Amount:");
                            decimal amount = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Payment Status:");
                            string paymentStatus = Console.ReadLine();
                      

                            task.RecordPayment(new Payments { PaymentId = paymentId, OrderId = orderId, Amount = amount, Status = paymentStatus });
                            Console.WriteLine("Payment recorded successfully.");
                            break;

                        case 11:
                            
                            Console.WriteLine("Enter Payment ID to Update:");
                            paymentId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter New Payment Status:");
                            paymentStatus = Console.ReadLine();

                            task.UpdatePaymentStatus(paymentId, paymentStatus);
                            Console.WriteLine("Payment status updated successfully.");
                            break;

                        case 0:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine($"Error: {ex.Message}");
                    
                }
            }
        }
       

    }
}