using E_Commerce_Platform_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Platform_Project.Models_Configuration
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ProductId);

            builder.HasOne(e => e.Category)
                   .WithMany(e => e.Products)
                   .HasForeignKey(e => e.CategoryId);
            builder.HasMany(e => e.OrderDetails)
                   .WithOne(e => e.Product)
                   .HasForeignKey(e => e.ProductId);
            builder.Property(e => e.Price)
                   .HasPrecision(18, 2);

            builder.HasData(
                // Electronics
                new Product { ProductId = 1, Name = "Smartphone", Description = "Latest model with 5G support", Price = 999.99M, Stock = 200, CategoryId = 1 },
                new Product { ProductId = 2, Name = "Laptop", Description = "High performance laptop", Price = 1499.99M, Stock = 150, CategoryId = 1 },
                new Product { ProductId = 3, Name = "Smartwatch", Description = "Fitness tracking smartwatch", Price = 199.99M, Stock = 300, CategoryId = 1 },

                // Clothing
                new Product { ProductId = 4, Name = "T-shirt", Description = "Cotton T-shirt", Price = 19.99M, Stock = 500, CategoryId = 2 },
                new Product { ProductId = 5, Name = "Jeans", Description = "Denim jeans", Price = 39.99M, Stock = 350, CategoryId = 2 },
                new Product { ProductId = 6, Name = "Jacket", Description = "Winter jacket", Price = 79.99M, Stock = 120, CategoryId = 2 },

                // Home Appliances
                new Product { ProductId = 7, Name = "Microwave Oven", Description = "High power microwave oven", Price = 89.99M, Stock = 100, CategoryId = 3 },
                new Product { ProductId = 8, Name = "Blender", Description = "Smoothie blender", Price = 49.99M, Stock = 150, CategoryId = 3 },

                // Books
                new Product { ProductId = 9, Name = "The Great Gatsby", Description = "Classic novel by F. Scott Fitzgerald", Price = 10.99M, Stock = 500, CategoryId = 4 },
                new Product { ProductId = 10, Name = "1984", Description = "Dystopian novel by George Orwell", Price = 12.99M, Stock = 450, CategoryId = 4 },

                // Toys
                new Product { ProductId = 11, Name = "Toy Car", Description = "Remote controlled car", Price = 29.99M, Stock = 200, CategoryId = 5 },
                new Product { ProductId = 12, Name = "Building Blocks", Description = "Set of colorful building blocks", Price = 19.99M, Stock = 400, CategoryId = 5 }
            );
        }
    }
}
