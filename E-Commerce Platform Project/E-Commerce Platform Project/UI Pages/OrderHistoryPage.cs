using E_Commerce_Platform_Project.Models;
using E_Commerce_Platform_Project.Repository;
using E_Commerce_Platform_Project.Context;
using System;
using System.Linq;

namespace E_Commerce_Platform_Project
{
    internal class OrderHistoryPage
    {
        private readonly OrderRepos _orderRepos;
        private readonly OrderDetailsRepos _orderDetailsRepos;

        public OrderHistoryPage(EcommerceContextDB cntx)
        {
            _orderRepos = new OrderRepos(cntx);
            _orderDetailsRepos = new OrderDetailsRepos(cntx);
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("\n--- Order History ---");

            Order _order = null;
            do
            {
                Console.Write("Enter Order ID: ");
                int customerId = int.Parse(Console.ReadLine());
                _order = _orderRepos.GetByCustomerId(customerId);
                if (_order == null)
                {
                    Console.WriteLine("Invalid Id, try again!");
                }
            } while (_order == null);

            var orders = _orderRepos.GetOrdersByCustomerId(_order.CustomerId);

            if (orders.Count == 0)
            {
                Console.WriteLine("No orders found for this customer.");
            }
            else
            {
                foreach (var order in orders)
                {
                    Console.WriteLine($"\nOrder Name : {order.Customer.FirstName} {order.Customer.LastName}");

                    Console.WriteLine($"\nOrder ID: {order.OrderId}");
                    Console.WriteLine($"Order Date: {order.OrderDate}");
                    Console.WriteLine($"Total Amount: {order.TotalAmount:C}");

                    var orderDetails = _orderDetailsRepos.GetOrderDetailsByOrderId(order.OrderId);

                    Console.WriteLine("\nOrder Items:");
                    foreach (var orderDetail in orderDetails)
                    {
                        Console.WriteLine($"- Product Name: {orderDetail.Product.Name}");
                        Console.WriteLine($"  Quantity: {orderDetail.Quantity}");
                        Console.WriteLine($"  Price at Purchase: {orderDetail.Price:C}");
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
