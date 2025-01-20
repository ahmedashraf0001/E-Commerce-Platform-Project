using E_Commerce_Platform_Project.Models;
using E_Commerce_Platform_Project.Repository;
using E_Commerce_Platform_Project.Context;
using System;
using System.Linq;

namespace E_Commerce_Platform_Project
{
    internal class CategoryManagementPage
    {
        private readonly CategoryRepos _repos;

        public CategoryManagementPage(EcommerceContextDB cntx)
        {
            _repos = new CategoryRepos(cntx);
        }

        public void Display()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("\n--- Category Management ---");
                Console.WriteLine("1. Add Category");
                Console.WriteLine("2. Update Category");
                Console.WriteLine("3. Delete Category");
                Console.WriteLine("4. View Categories Products");
                Console.WriteLine("5. View Categories");
                Console.WriteLine("6. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCategory();
                        break;
                    case "2":
                        UpdateCategory();
                        break;
                    case "3":
                        DeleteCategory();
                        break;
                    case "4":
                        ViewCategoriesProducts();
                        break;
                    case "5":
                        ViewCategories();
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

        private void AddCategory()
        {
            Console.WriteLine("\n--- Add Category ---");
            Console.Write("Category Name: ");
            var name = Console.ReadLine();
            Console.Write("Description: ");
            var description = Console.ReadLine();

            var category = new Category
            {
                Name = name
            };

            _repos.Add(category);
            Console.WriteLine("Category added successfully!");
            Console.ReadLine();
        }

        private void UpdateCategory()
        {
            Console.WriteLine("\n--- Update Category ---");

            Category category = null;

            // Loop to find the category ID
            do
            {
                Console.Write("Enter Category ID: ");
                int categoryId = int.Parse(Console.ReadLine());
                category = _repos.GetByID(categoryId);

                if (category == null)
                {
                    Console.WriteLine("Invalid Category ID, try again!");
                }

            } while (category == null);

            Console.Write("Name ({0}): ", category.Name);
            var name = Console.ReadLine();

            // Update category details
            category.Name = string.IsNullOrEmpty(name) ? category.Name : name;

            _repos.Update(category);
            Console.WriteLine("Category updated successfully!");
            Console.ReadLine();
        }

        private void DeleteCategory()
        {
            Console.WriteLine("\n--- Delete Category ---");

            Category category = null;

            // Loop to find the category ID
            do
            {
                Console.Write("Enter Category ID: ");
                int categoryId = int.Parse(Console.ReadLine());
                category = _repos.GetByID(categoryId);

                if (category == null)
                {
                    Console.WriteLine("Invalid Category ID, try again!");
                }

            } while (category == null);

            _repos.Delete(category.CategoryId);
            Console.WriteLine("Category deleted successfully!");
            Console.ReadLine();
        }

        private void ViewCategories()
        {
            Console.WriteLine("\n--- View Categories ---");
            var categories = _repos.All();

            if (categories.Count == 0)
            {
                Console.WriteLine("No categories available.");
            }
            else
            {
                foreach (var category in categories)
                {
                    Console.WriteLine($"ID: {category.CategoryId}, Name: {category.Name}\n");
                }
            }

            Console.ReadLine();
        }
        private void ViewCategoriesProducts()
        {
            Console.WriteLine("\n--- View Categories and Products ---");

            // Get all categories
            var categories = _repos.All();

            if (categories.Count == 0)
            {
                Console.WriteLine("No categories available.");
            }
            else
            {
                foreach (var category in categories)
                {
                    Console.WriteLine($"\nCategory: {category.Name}");

                    // Get products for this category
                    var productsInCategory = _repos.All().Where(p => p.CategoryId == category.CategoryId).ToList();

                    if (productsInCategory.Count == 0)
                    {
                        Console.WriteLine("No products found under this category.");
                    }
                    else
                    {
                        foreach (var prod in productsInCategory)
                        {
                           foreach(var product in prod.Products)
                            {
                                Console.WriteLine($"- Product Name: {product.Name}");
                                Console.WriteLine($"  Description: {product.Description}");
                                Console.WriteLine($"  Price: {product.Price:C}");
                                Console.WriteLine($"  Stock: {product.Stock}\n");
                            }
                        }
                    }
                }
            }

            Console.ReadLine();
        }

    }
}
