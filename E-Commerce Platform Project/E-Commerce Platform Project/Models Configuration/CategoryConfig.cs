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
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { CategoryId = 1, Name = "Electronics" },
                new Category { CategoryId = 2, Name = "Clothing" },
                new Category { CategoryId = 3, Name = "Home Appliances" },
                new Category { CategoryId = 4, Name = "Books" },
                new Category { CategoryId = 5, Name = "Toys" }
            );

        }
    }
}
