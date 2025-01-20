using E_Commerce_Platform_Project.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Platform_Project.UI_Pages
{
    internal class MainMenu
    {
        ProductManagementPage productManagementPage;
        CustomerManagementPage customerManagementPage;
        CategoryManagementPage categoryManagementPage;
        OrderPlacementPage orderPlacementPage;
        OrderHistoryPage orderHistoryPage;

        public MainMenu(EcommerceContextDB cntx)
        {
            productManagementPage = new ProductManagementPage(cntx);
            customerManagementPage = new CustomerManagementPage(cntx);
            categoryManagementPage = new CategoryManagementPage(cntx);
            orderHistoryPage = new OrderHistoryPage(cntx);
            orderPlacementPage = new OrderPlacementPage(cntx);
        }
        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Product Management");
                Console.WriteLine("2. Customer Management");
                Console.WriteLine("3. Category Management");
                Console.WriteLine("4. Place an Order");
                Console.WriteLine("5. View Order History");
                Console.WriteLine("0. Exit");

                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        productManagementPage.Display();
                        break;
                    case "2":
                        customerManagementPage.Display();
                        break;
                    case "3":
                        categoryManagementPage.Display();
                        break;
                    case "4":
                        orderPlacementPage.Display();
                        break;
                    case "5":
                        orderHistoryPage.Display();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
