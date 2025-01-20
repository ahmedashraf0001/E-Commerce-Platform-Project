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
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.OrderId);
            builder.HasOne(e => e.Customer)
                        .WithMany(e => e.Orders)
                        .HasForeignKey(e => e.CustomerId);
            builder.HasMany(e => e.OrderDetails)
                        .WithOne(e => e.Order)
                        .HasForeignKey(e => e.OrderId);

            builder.HasData(
                new Order { OrderId = 1, OrderDate = DateTime.Now.AddDays(-2), CustomerId = 1 },
                new Order { OrderId = 2, OrderDate = DateTime.Now.AddDays(-1), CustomerId = 2 },
                new Order { OrderId = 3, OrderDate = DateTime.Now.AddDays(-3), CustomerId = 3 },
                new Order { OrderId = 4, OrderDate = DateTime.Now.AddDays(-5), CustomerId = 4 },
                new Order { OrderId = 5, OrderDate = DateTime.Now.AddDays(-7), CustomerId = 5 }
            );


        }
    }
}
