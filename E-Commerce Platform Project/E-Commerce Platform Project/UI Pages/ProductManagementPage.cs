using E_Commerce_Platform_Project.Models;
using E_Commerce_Platform_Project.Repository;
using E_Commerce_Platform_Project.Context;
using System;

namespace E_Commerce_Platform_Project
{
    internal class ProductManagementPage
    {
        private readonly ProductRepos _repos;

        public ProductManagementPage(EcommerceContextDB cntx)
        {
            _repos = new ProductRepos(cntx);
        }

        public void Display()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("\n--- Product Management ---");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. View Products");
                Console.WriteLine("5. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        UpdateProduct();
                        break;
                    case "3":
                        DeleteProduct();
                        break;
                    case "4":
                        ViewProducts();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void AddProduct()
        {
            Console.Clear();
            Console.WriteLine("\n--- Add Product ---");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Description: ");
            var description = Console.ReadLine();
            Console.Write("Price: ");
            var price = decimal.Parse(Console.ReadLine());
            Console.Write("Stock Quantity: ");
            var stockQuantity = int.Parse(Console.ReadLine());
            Console.Write("Category ID: ");
            var categoryId = int.Parse(Console.ReadLine());

            var product = new Product
            {
                Name = name,
                Description = description,
                Price = price,
                Stock = stockQuantity,
                CategoryId = categoryId
            };

            _repos.Add(product);
            Console.WriteLine("Product added successfully!"); 
            Console.WriteLine("Press Any Key To Continue.");
            Console.ReadLine();
        }

        private void UpdateProduct()
        {
            Console.Clear();
            Console.WriteLine("\n--- Update Product ---");
            Product product = null;
            do
            {
                Console.Write("Enter Product ID: ");
                int customerId = int.Parse(Console.ReadLine());
                product = _repos.GetByID(customerId);
                if (product == null)
                {
                    Console.WriteLine("invalid Id, try again!");
                }
            } while (product == null);

            Console.Write("Name ({0}): ", product.Name);
            var name = Console.ReadLine();
            Console.Write("Description ({0}): ", product.Description);
            var description = Console.ReadLine();
            Console.Write("Price ({0}): ", product.Price);
            var price = decimal.TryParse(Console.ReadLine(), out decimal newPrice) ? newPrice : product.Price;
            Console.Write("Stock Quantity ({0}): ", product.Stock);
            var stockQuantity = int.TryParse(Console.ReadLine(), out int newStock) ? newStock : product.Stock;
            Console.Write("Category ID ({0}): ", product.CategoryId);
            var categoryId = int.TryParse(Console.ReadLine(), out int newCategoryId) ? newCategoryId : product.CategoryId;

            product.Name = string.IsNullOrEmpty(name) ? product.Name : name;
            product.Description = string.IsNullOrEmpty(description) ? product.Description : description;
            product.Price = price;
            product.Stock = stockQuantity;
            product.CategoryId = categoryId;

            _repos.Update(product);
            Console.WriteLine("Product updated successfully!");
            Console.WriteLine("Press Any Key To Continue.");
            Console.ReadLine();
        }

        private void DeleteProduct()
        {
            Console.Clear();
            Console.WriteLine("\n--- Delete Product ---");
            Product product = null;
            do
            {
                Console.Write("Enter Product ID: ");
                int customerId = int.Parse(Console.ReadLine());
                product = _repos.GetByID(customerId);
                if (product == null)
                {
                    Console.WriteLine("invalid Id, try again!");
                }
            } while (product == null);

            _repos.Delete(product.ProductId);
            Console.WriteLine("Product deleted successfully!");
            Console.WriteLine("Press Any Key To Continue.");
            Console.ReadLine();
        }

        private void ViewProducts()
        {
            Console.Clear();
            Console.WriteLine("\n--- View Products ---");
            var products = _repos.All();

            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
            }
            else
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Category: {product.Category.Name}\n");
                    Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Price: {product.Price:C}, Stock: {product.Stock}");
                    Console.WriteLine($"Category ID: {product.CategoryId}");
                    Console.WriteLine($"Description: {product.Description}\n");
                    Console.WriteLine("====================================================================================================");
                }
            }
            Console.WriteLine("Press Any Key To Continue.");
            Console.ReadLine();
        }
    }
}
