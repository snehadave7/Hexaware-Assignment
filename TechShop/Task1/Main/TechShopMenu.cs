using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Dao;
using TechShop.Model;
using TechShop.Util;
namespace TechShop.Main {
    internal class TechShopMenu {
        string adminUsername = "Admin";
        string adminPassword = "password";
        Customers currentUser = null;

        CustomerRepository customerRepository = new CustomerRepository();
        InventoryRepository inventoryRepository = new InventoryRepository();
        OrderDetailsRepository orderDetailsRepository = new OrderDetailsRepository();
        OrdersRepository ordersRepository = new OrdersRepository();
        ProductsRepository productsRepository = new ProductsRepository();
        public void Run() {
            using (DBConnection dbConnection = new DBConnection()) {

                if (dbConnection.TestConnection()) {
                    Console.WriteLine("Connection successful!");
                first:
                    Console.WriteLine("Enter 1: Registration");
                    Console.WriteLine("Enter 2: User Login");
                    Console.WriteLine("Enter 3: Admin Login");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice) {
                        case 1:
                        Register:
                            Console.WriteLine("Enter Email");
                            string email = Console.ReadLine();
                            if (customerRepository.CheckExistingEmail(dbConnection, email)) {
                                Console.WriteLine("Email already exists! Login"); goto Login;
                            }
                            if (!email.Contains("@"))
    {
        throw new InvalidDataException("Invalid email address.");
    }
                            Console.WriteLine("Enter FirstName");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Enter LastName");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Enter Phone");
                            string phone = Console.ReadLine();
                            Console.WriteLine("Enter Address");
                            string address = Console.ReadLine();

                            int customerId = customerRepository.GetNewCustomerId(dbConnection);
                            Customers customer = new Customers(customerId, firstName, lastName, email, phone, address);
                            currentUser = customer;
                            customerRepository.CreateNewCustomer(dbConnection, customer);
                            goto Login;
                            break;
                        case 2:
                        Login:
                            Console.WriteLine("Enter Registered Email to login");
                            string registeredEmail = Console.ReadLine();
                            if (!customerRepository.CheckExistingEmail(dbConnection, registeredEmail)) {
                                Console.WriteLine("Email does not exists! Register first"); goto Register;
                            }
                            else {
                                Console.WriteLine("Login successfull");
                                currentUser = customerRepository.GetCustomerDetails(dbConnection, registeredEmail);
                                goto menu;
                            }
                            break;
                        case 3:
                        admin:
                            Console.WriteLine("Enter username");
                            string username = Console.ReadLine();
                            Console.WriteLine("Enter password");
                            string password = Console.ReadLine();
                            if (username == adminUsername && password == adminPassword) {
                                Console.WriteLine("Login Successful"); goto adminMenu;
                            }
                            else {
                                Console.WriteLine("Wrong credentials! Try again"); goto admin;
                            }
                            break;

                        default:
                            Console.WriteLine("Wrong choice! Try Again"); goto first;
                            break;

                    }
                menu:
                    Console.WriteLine("Enter 1: To view Product Catalog");
                    Console.WriteLine("Enter 2: To place an Order");
                    Console.WriteLine("Enter 3: To track Order Status");
                    Console.WriteLine("Enter 4: To update Customer details");
                    Console.WriteLine("Enter 5: To search a product");

                    int option = int.Parse(Console.ReadLine());

                    switch (option) {
                        case 1:
                            productsRepository.GetProductDetails(dbConnection);
                            Console.WriteLine("Enter 6: To go back to main menu"); goto menu;
                            break;
                        case 2:
                        menuCase2:
                            Console.WriteLine("LIST OF AVAILABLE PRODUCTS");
                            productsRepository.GetProductDetails(dbConnection);

                            Console.WriteLine("Enter the productId for the product you wish to order");
                            int productId = int.Parse(Console.ReadLine());

                            if (inventoryRepository.isProductInStock(dbConnection, productId)) {
                                int availableQuantity = inventoryRepository.GetQuantityInStock(dbConnection, productId);
                            invalidQuantity:
                                Console.WriteLine($"Available quantity of this product is: {availableQuantity}");
                                Console.WriteLine("Enter the amount of product you wish to place");
                                int orderQuantity = int.Parse(Console.ReadLine());
                                if (orderQuantity > availableQuantity) {
                                    Console.WriteLine("Invalid Entry");
                                    goto invalidQuantity;
                                }
                                else {

                                    Customers customer = customerRepository.GetCustomerDetails(dbConnection, currentUser.Email);

                                    int orderId = ordersRepository.GetOrderId(dbConnection);

                                    decimal totalAmount = ordersRepository.CalculateTotalAmount(dbConnection, orderQuantity, productId);

                                    Orders order = new Orders(orderId, DateTime.Now, totalAmount, customer);

                                    ordersRepository.AddOrders(dbConnection, order);

                                    Products product = productsRepository.GetSingleProductDetails(dbConnection, productId);

                                    OrderDetails orderDetails = new OrderDetails(order, product, orderQuantity);
                                    orderDetailsRepository.AddOrderDetails(dbConnection, orderDetails);

                                    inventoryRepository.UpdateStockQuantity(dbConnection, orderQuantity, productId);
                                    Console.WriteLine("Order Placed successfully!!");
                                }
                            }
                            else {
                                Console.WriteLine("Product Stock currently unavailable");
                                goto menuCase2;
                            }

                            break;
                        case 3:
                            Console.WriteLine("Enter orderId");
                            int orderId1 = int.Parse(Console.ReadLine());
                            ordersRepository.CheckStatus(dbConnection, orderId1);
                            break;

                        case 4:
                            Console.WriteLine("Enter the contact");
                            string contact = Console.ReadLine();
                            Console.WriteLine("Enter customerId");
                            int id = int.Parse(Console.ReadLine());
                            customerRepository.UpdateCustomerInfo(contact, id, dbConnection);
                            Console.WriteLine("COntact updated successfully");

                            break;
                        case 5:
                            Console.WriteLine("Which category do you wish to search: Computer,HomeAppliance,Accessory,SoundDevice");
                            string categoryChoice = Console.ReadLine();

                            productsRepository.SearchByCategory(dbConnection, categoryChoice);


                            break;
                        default:
                            Console.WriteLine("Wrong Choice! Enter again"); goto menu;
                            break;
                    }

                adminMenu:
                    Console.WriteLine("Enter 1: Inventory Management");
                    Console.WriteLine("Enter 2: Check sales");

                    int adminOption = int.Parse(Console.ReadLine());

                    switch (adminOption) {
                        case 1:
                            Console.WriteLine("Add products");
                            Console.WriteLine("Update stocks");
                            Console.WriteLine("Remove products");
                            int choice1 = int.Parse(Console.ReadLine());
                            switch (choice1) {
                                case 1:
                                    Console.WriteLine("Name");
                                    string name = Console.ReadLine();
                                    Console.WriteLine("Description");
                                    string des = Console.ReadLine();
                                    Console.WriteLine("Price");
                                    int price = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Category");
                                    string category = Console.ReadLine();
                                    Products product = new Products(name, des, price, category);
                                    productsRepository.AddProduct(dbConnection, product);
                                    break;
                                case 2:
                                    Console.WriteLine("Enter the productId");
                                    int productId = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter new stock ");
                                    int newQuantity = int.Parse(Console.ReadLine());
                                    inventoryRepository.UpdateStock(dbConnection, newQuantity, productId);
                                    break;
                                case 3:
                                    Console.WriteLine("Removed discontinued items");
                                    inventoryRepository.DiscontinueItem(dbConnection);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 2:
                            Console.WriteLine("Total sales produced by techShop is");
                            ordersRepository.CalculateTotalSales(dbConnection);
                            break;

                        default:
                            Console.WriteLine("Wrong value entered");
                            goto menu;
                            break;
                    }


                }
                else {
                    Console.WriteLine("Failed to connect to the database.");
                }

            }
        }
    
    }
}
