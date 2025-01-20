using E_Commerce_Platform_Project.Models;
using E_Commerce_Platform_Project.Repository;
using E_Commerce_Platform_Project.Context;
using System;
using System.Linq;

namespace E_Commerce_Platform_Project
{
    internal class OrderPlacementPage
    {
        private readonly ProductRepos _productRepos;
        private readonly OrderRepos _orderRepos;
        private readonly OrderDetailsRepos _orderDetailsRepos;

        public OrderPlacementPage(EcommerceContextDB cntx)
        {
            _productRepos = new ProductRepos(cntx);
            _orderRepos = new OrderRepos(cntx);
            _orderDetailsRepos = new OrderDetailsRepos(cntx);
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("\n--- Order Placement ---");

            // Search for the customer by ID
            Order customer = null;
            do
            {
                Console.Write("Enter Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());
                customer = _orderRepos.GetByCustomerId(customerId);
                if (customer == null)
                {
                    Console.WriteLine("Invalid Id, try again!");
                }
            } while (customer == null);

            // Start creating the order
            var order = new Order
            {
                CustomerId = customer.CustomerId,
                OrderDate = DateTime.Now,
            };

            _orderRepos.Add(order); // Save order first to get the OrderId

            Console.WriteLine("Order has been created! Now, let's add products.");

            // Keep adding products to the order
            bool addingProducts = true;
            while (addingProducts)
            {
                // Show available products
                Console.WriteLine("\nAvailable Products:");
                var products = _productRepos.All();
                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Price: {product.Price:C}, Stock: {product.Stock}");
                }

                // Get product selection
                Product selectedProduct = null;
                do
                {
                    Console.Write("\nEnter Product ID to add to order: ");
                    int productId = int.Parse(Console.ReadLine());
                    selectedProduct = _productRepos.GetByID(productId);
                    if (selectedProduct == null)
                    {
                        Console.WriteLine("Invalid Product ID, try again!");
                    }
                } while (selectedProduct == null);

                // Get quantity for the selected product
                int quantity = 0;
                do
                {
                    Console.Write($"Enter quantity for {selectedProduct.Name}: ");
                    quantity = int.Parse(Console.ReadLine());

                    if (quantity <= 0)
                    {
                        Console.WriteLine("Quantity must be greater than zero.");
                    }
                    else if (quantity > selectedProduct.Stock)
                    {
                        Console.WriteLine($"Insufficient stock. Available stock is {selectedProduct.Stock}.");
                    }
                } while (quantity <= 0 || quantity > selectedProduct.Stock);

                // Add product to order details
                var orderDetail = new OrderDetails
                {
                    OrderId = order.OrderId,
                    ProductId = selectedProduct.ProductId,
                    Quantity = quantity,
                    Price = selectedProduct.Price  // Store the price of the product at the time of purchase
                };

                _orderDetailsRepos.Add(orderDetail);

                // Update product stock
                selectedProduct.Stock -= quantity;
                _productRepos.Update(selectedProduct);

                // Update total order amount
                _orderRepos.Update(order);

                Console.WriteLine($"{quantity} x {selectedProduct.Name} added to the order.");

                // Ask if the customer wants to add more products
                Console.Write("\nWould you like to add another product? (Y/N): ");
                var continueAdding = Console.ReadLine().ToUpper();
                if (continueAdding != "Y")
                {
                    addingProducts = false;
                }
            }

            // Display the final order details
            Console.WriteLine("\n--- Order Summary ---");
            Console.WriteLine($"Customer: {customer.Customer.FirstName} {customer.Customer.LastName}");
            Console.WriteLine($"Order ID: {order.OrderId}");
            Console.WriteLine($"Total Amount: {order.TotalAmount:C}");
            Console.WriteLine("Items:");
            var orderDetails = _orderDetailsRepos.GetOrderDetailsByOrderId(order.OrderId);
            foreach (var orderDetail in orderDetails)
            {
                var product = _productRepos.GetByID(orderDetail.ProductId);
                Console.WriteLine($"- {product.Name}: {orderDetail.Quantity} x {orderDetail.Price:C}");
            }

            Console.WriteLine("\nYour order has been placed successfully!");
            Console.ReadLine();
        }
    }
}
