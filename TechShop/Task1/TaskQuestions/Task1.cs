using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.TaskQuestions {
    internal class Task1 {
        public void Task() {
            #region Task-1
            #region Ques-1
            
            //1.You need to create a program that checks if a customer is eligible for a special discount
            //based on their loyalty points and total purchases.The eligibility criteria are:
            //Loyalty points must be above 100.
            //Total purchase must be at least Rs1, 000.
            Console.WriteLine("Enter the total amount of purchase");
            int totalAmount=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter available loyalty point");
            int loyaltyPoints=int.Parse(Console.ReadLine());

            if (loyaltyPoints > 100 && totalAmount>1000) {
                Console.WriteLine("You are eligible for special discount");
                int totalAmountAfterDiscount = totalAmount - (loyaltyPoints);
                Console.WriteLine($"Your total amount after applying discount is {totalAmountAfterDiscount}");
            }
            else if(loyaltyPoints<100){
                Console.WriteLine("Sorry! You are not eligible for dicount as your loyalty points are less than 100. Shop often to get more loyalty points");
            }
            else {
                Console.WriteLine("Sorry! You are not eligible for dicount. Shop for atleast Rs.1000 to avail the offer");
            }
            
            #endregion

            #region Ques-2
            
            //2 Create a program that simulates an electronics gadget purchase. Display options such as
            //"Check Available Stock," "Buy Product," "Return Product." Ask the user to enter the current
            //quantity, and for "Buy Product," prompt them to enter the quantity they want to buy. Ensure that
            //the quantity to buy is not greater than the available stock and that it is at least 1 unit.
            //Display appropriate messages for success or failure
          
            int availableStocks = 20;
            Label2:
            Console.WriteLine("Welcome to TechShop!");
            Console.WriteLine("Press 1: Check Available stocks");
            Console.WriteLine("Press 2: Buy Product");
            Console.WriteLine("Press 3: Return Product");
            int choice = int.Parse(Console.ReadLine());
            
            switch(choice){
                case 1:
                    Console.WriteLine($"The available Stockes for the gadget is {availableStocks}");
                    break;
                case 2:
                    Label:
                    Console.WriteLine("Enter the amount of product you wish to buy");
                    int quantityOfPurchase=int.Parse(Console.ReadLine());
                    if (quantityOfPurchase > availableStocks) {
                        Console.WriteLine($"Sorry! Only {availableStocks} stocks are left.");
                        Console.WriteLine("Order Again"); goto Label;
                    }
                    else if (quantityOfPurchase == 0) {
                        Console.WriteLine("Add the quantity of product you wish to order"); goto Label;
                    }
                    else {
                        Console.WriteLine("Congratulation! Order added to the cart");
                        availableStocks -= quantityOfPurchase;
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter the quantity you ordered");
                    int quanityToReturn=int.Parse(Console.ReadLine());
                    Console.WriteLine("You have successfully returned the products");
                    availableStocks += quanityToReturn;
                    break;
                default:
                    Console.WriteLine("Wrong Choice! Try Again"); goto Label2;
                    break;
            }

            
            #endregion

            #region Ques-3
            
            //3.create a program that allows customers to check the status of their orders. The program should
            //handle multiple customer orders, and the customer should be able to enter their order number to
            //check the status


            string[] status=new string[10];
            for(int i = 0; i < status.Length; i++) {
                if (i == 0 || i == 2 || i == 4) {
                    status[i] = "Shipped to local center";
                }
                else if (i == 1 || i == 3 || i == 5) {
                    status[i] = "OrderDispatched from main center";
                }
                else status[i] = "Will reach by today till 9PM";
            }

            Console.WriteLine("Enter to orderId to check your OrderStatus.");
            Console.WriteLine("Valid OrderId ranges from 0 to 9");
            int OrderId = int.Parse(Console.ReadLine());

            Console.WriteLine($"Your order status is:: {status[OrderId]}.");
            Console.WriteLine("ThankYou for visiting");
            
            #endregion

            #endregion

        }

    }
}
