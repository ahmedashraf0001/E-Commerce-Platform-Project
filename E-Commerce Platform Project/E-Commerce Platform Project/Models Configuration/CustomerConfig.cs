using E_Commerce_Platform_Project.Additional_Datatypes;
using E_Commerce_Platform_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_Platform_Project.Models_Configuration
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.CustomerId);

            builder.OwnsOne(e => e.Address, a =>
            {
                a.Property(p => p.CustomerId);
                a.Property(p => p.Street).HasColumnName("Address_Street");
                a.Property(p => p.City).HasColumnName("Address_City");
                a.Property(p => p.ZipCode).HasColumnName("Address_ZipCode");
            });

            builder.HasData(
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "123-456-7890",
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "234-567-8901",
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Emily",
                    LastName = "Johnson",
                    Email = "emily.johnson@example.com",
                    PhoneNumber = "345-678-9012",
                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = "Michael",
                    LastName = "Williams",
                    Email = "michael.williams@example.com",
                    PhoneNumber = "456-789-0123",
                },
                new Customer
                {
                    CustomerId = 5,
                    FirstName = "Sarah",
                    LastName = "Brown",
                    Email = "sarah.brown@example.com",
                    PhoneNumber = "567-890-1234",
                }
            );

            builder.OwnsOne(e => e.Address).HasData(
                new
                {
                    CustomerId = 1,
                    Street = "123 Elm St",
                    City = "New York",
                    ZipCode = "10001"
                },
                new
                {
                    CustomerId = 2,
                    Street = "456 Oak St",
                    City = "Los Angeles",
                    ZipCode = "90001"
                },
                new
                {
                    CustomerId = 3,
                    Street = "789 Pine St",
                    City = "Chicago",
                    ZipCode = "60007"
                },
                new
                {
                    CustomerId = 4,
                    Street = "101 Maple St",
                    City = "Houston",
                    ZipCode = "77001"
                },
                new
                {
                    CustomerId = 5,
                    Street = "202 Birch St",
                    City = "Phoenix",
                    ZipCode = "85001"
                }
            );
        }
    }
}
