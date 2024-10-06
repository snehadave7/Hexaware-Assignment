
using TechShop.Main;

namespace Task1 {
    internal class Program {
        static void Main(string[] args) {
            TechShopMenu menu = new TechShopMenu();
            CollectionTaskMenu collectionTaskMenu = new CollectionTaskMenu();
            Console.WriteLine("Enter 1: To view DatabaseMenu");
            Console.WriteLine("Enter 2: To view CollectionsMenu");
            Console.WriteLine("Enter 3: To exit");
            int choice=int.Parse(Console.ReadLine());
            switch (choice) {
                case 1:
                    menu.Run();
                    break;
                case 2:
                    collectionTaskMenu.CollectionTaskRun();
                    break;
                case 3:
                    return;
            }
            
        
        }

    }
}
