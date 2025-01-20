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
    internal class OrderDetailsConfig : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.HasKey(e => new { e.OrderId, e.ProductId });

            builder.Property(e => e.Price)
                        .HasPrecision(18, 2);


            builder.HasData(
                // Order 1 details
                new OrderDetails { OrderId = 1, ProductId = 1, Quantity = 1, Price = 999.99M },
                new OrderDetails { OrderId = 1, ProductId = 3, Quantity = 2, Price = 199.99M },

                // Order 2 details
                new OrderDetails { OrderId = 2, ProductId = 2, Quantity = 1, Price = 1499.99M },
                new OrderDetails { OrderId = 2, ProductId = 4, Quantity = 3, Price = 19.99M },

                // Order 3 details
                new OrderDetails { OrderId = 3, ProductId = 7, Quantity = 1, Price = 89.99M },
                new OrderDetails { OrderId = 3, ProductId = 8, Quantity = 2, Price = 49.99M },

                // Order 4 details
                new OrderDetails { OrderId = 4, ProductId = 10, Quantity = 1, Price = 12.99M },
                new OrderDetails { OrderId = 4, ProductId = 9, Quantity = 2, Price = 10.99M },

                // Order 5 details
                new OrderDetails { OrderId = 5, ProductId = 11, Quantity = 1, Price = 29.99M },
                new OrderDetails { OrderId = 5, ProductId = 12, Quantity = 3, Price = 19.99M }
            );

        }
    }
}
