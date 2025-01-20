using E_Commerce_Platform_Project.Context;
using E_Commerce_Platform_Project.UI_Pages;

namespace E_Commerce_Platform_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the E-Commerce Platform!");
            var context = new EcommerceContextDB();
            var run = new MainMenu(context);
            run.Menu();
        }

        
    }
}
