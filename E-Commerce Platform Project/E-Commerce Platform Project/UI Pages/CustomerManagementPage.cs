using E_Commerce_Platform_Project.Additional_Datatypes;
using E_Commerce_Platform_Project.Context;
using E_Commerce_Platform_Project.Models;
using E_Commerce_Platform_Project.Repository;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Platform_Project.UI_Pages
{
    internal class CustomerManagementPage
    {
        private readonly CustomerRepos _repos;

        public CustomerManagementPage(EcommerceContextDB cntx)
        {
            _repos = new CustomerRepos(cntx);
        }

        public void Display()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("\n--- Customer Management ---");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Update Customer");
                Console.WriteLine("3. Delete Customer");
                Console.WriteLine("4. View Customers");
                Console.WriteLine("5. View Customers Orders");
                Console.WriteLine("6. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCustomer();
                        break;
                    case "2":
                        UpdateCustomer();
                        break;
                    case "3":
                        DeleteCustomer();
                        break;
                    case "4":
                        ViewCustomers();
                        break;
                    case "5":
                        ViewCustomerOrders();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        public void AddCustomer()
        {
            Console.Clear();
            Console.WriteLine("\n--- Add Customer ---");
            Console.Write("First Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Phone Number: ");
            var phoneNumber = Console.ReadLine();
            Console.Write("Street: ");
            var street = Console.ReadLine();
            Console.Write("City: ");
            var city = Console.ReadLine();
            Console.Write("Zip Code: ");
            var zipCode = Console.ReadLine();

            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = new FullAddress
                {
                    Street = street,
                    City = city,
                    ZipCode = zipCode
                }
            };

            _repos.Add(customer);
            Console.WriteLine("Customer added successfully!");
            Console.WriteLine("Press Any Key To Continue.");

            Console.ReadKey();
        }
        public void UpdateCustomer()
        {
            Console.Clear();
            Console.WriteLine("\n--- Update Customer ---");
            Customer customer = null;
            do
            {
                Console.Write("Enter Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());
                customer = _repos.GetByID(customerId);
                if (customer == null)
                {
                    Console.WriteLine("invalid Id, try again!");
                }
            } while (customer == null);

            Console.Write("First Name ({0}): ", customer.FirstName);
            var firstName = Console.ReadLine();
            Console.Write("Last Name ({0}): ", customer.LastName);
            var lastName = Console.ReadLine();
            Console.Write("Email ({0}): ", customer.Email);
            var email = Console.ReadLine();
            Console.Write("Phone Number ({0}): ", customer.PhoneNumber);
            var phoneNumber = Console.ReadLine();
            Console.Write("Street ({0}): ", customer.Address.Street);
            var street = Console.ReadLine();
            Console.Write("City ({0}): ", customer.Address.City);
            var city = Console.ReadLine();
            Console.Write("Zip Code ({0}): ", customer.Address.ZipCode);
            var zipCode = Console.ReadLine();

            customer.FirstName = string.IsNullOrEmpty(firstName) ? customer.FirstName : firstName;
            customer.LastName = string.IsNullOrEmpty(lastName) ? customer.LastName : lastName;
            customer.Email = string.IsNullOrEmpty(email) ? customer.Email : email;
            customer.PhoneNumber = string.IsNullOrEmpty(phoneNumber) ? customer.PhoneNumber : phoneNumber;
            customer.Address.Street = string.IsNullOrEmpty(street) ? customer.Address.Street : street;
            customer.Address.City = string.IsNullOrEmpty(city) ? customer.Address.City : city;
            customer.Address.ZipCode = string.IsNullOrEmpty(zipCode) ? customer.Address.ZipCode : zipCode;

            _repos.Update(customer);
            Console.WriteLine("Customer updated successfully!");
            Console.WriteLine("Press Any Key To Continue.");

            Console.ReadLine();
        }

        private void ViewCustomerOrders()
        {
            Console.Clear();
            Console.WriteLine("\n--- View Customer ---");
            Customer customer = null;
            do
            {
                Console.Write("Enter Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());
                customer = _repos.GetByID(customerId);
                if (customer == null)
                {
                    Console.WriteLine("invalid Id, try again!");
                }
            } while (customer == null);

            foreach (var order in customer.Orders)
            {
                Console.WriteLine($"Order ID: {order.OrderId}");
                Console.WriteLine($"Order Date: {order.OrderDate}");
                Console.WriteLine($"Total Amount: {order.TotalAmount:C}");
                Console.WriteLine("Order Details:");

                foreach (var orderDetail in order.OrderDetails)
                {
                    Console.WriteLine($"\tProduct: {orderDetail.Product.Name}, Quantity: {orderDetail.Quantity}, Price: {orderDetail.Price:C}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Press Any Key To Continue.");
            Console.ReadLine();
        }
        private void DeleteCustomer()
        {
            Console.WriteLine("\n--- Delete Customer ---");
            Customer customer = null;
            do
            {
                Console.Write("Enter Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());
                customer = _repos.GetByID(customerId);
                if (customer == null)
                {
                    Console.WriteLine("invalid Id, try again!");
                }
            } while (customer == null);

            _repos.Delete(customer.CustomerId);
            Console.WriteLine("Customer deleted successfully!");
            Console.WriteLine("Press Any Key To Continue.");
            Console.ReadLine();
        }

        private void ViewCustomers()
        {
            Console.WriteLine("\n--- View Customers ---");
            var customers = _repos.All();

            if (customers.Count == 0)
            {
                Console.WriteLine("No customers available.");
            }
            else
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine($"ID: {customer.CustomerId}, Name: {customer.FirstName} {customer.LastName}, Email: {customer.Email}");
                    Console.WriteLine($"Address: {customer.Address.Street}, {customer.Address.City}, {customer.Address.ZipCode}");
                    Console.WriteLine($"Phone: {customer.PhoneNumber}\n");
                }
            }
            Console.WriteLine("Press Any Key To Continue.");
            Console.ReadLine();
        }
    }
}
