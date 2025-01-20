using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerce_Platform_Project.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Clothing" },
                    { 3, "Home Appliances" },
                    { 4, "Books" },
                    { 5, "Toys" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address_City", "Address_Street", "Address_ZipCode", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "New York", "123 Elm St", "10001", "john.doe@example.com", "John", "Doe", "123-456-7890" },
                    { 2, "Los Angeles", "456 Oak St", "90001", "jane.smith@example.com", "Jane", "Smith", "234-567-8901" },
                    { 3, "Chicago", "789 Pine St", "60007", "emily.johnson@example.com", "Emily", "Johnson", "345-678-9012" },
                    { 4, "Houston", "101 Maple St", "77001", "michael.williams@example.com", "Michael", "Williams", "456-789-0123" },
                    { 5, "Phoenix", "202 Birch St", "85001", "sarah.brown@example.com", "Sarah", "Brown", "567-890-1234" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 4, 23, 29, 35, 574, DateTimeKind.Local).AddTicks(2769) },
                    { 2, 2, new DateTime(2024, 11, 5, 23, 29, 35, 574, DateTimeKind.Local).AddTicks(2817) },
                    { 3, 3, new DateTime(2024, 11, 3, 23, 29, 35, 574, DateTimeKind.Local).AddTicks(2818) },
                    { 4, 4, new DateTime(2024, 11, 1, 23, 29, 35, 574, DateTimeKind.Local).AddTicks(2820) },
                    { 5, 5, new DateTime(2024, 10, 30, 23, 29, 35, 574, DateTimeKind.Local).AddTicks(2827) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Latest model with 5G support", "Smartphone", 999.99m, 200 },
                    { 2, 1, "High performance laptop", "Laptop", 1499.99m, 150 },
                    { 3, 1, "Fitness tracking smartwatch", "Smartwatch", 199.99m, 300 },
                    { 4, 2, "Cotton T-shirt", "T-shirt", 19.99m, 500 },
                    { 5, 2, "Denim jeans", "Jeans", 39.99m, 350 },
                    { 6, 2, "Winter jacket", "Jacket", 79.99m, 120 },
                    { 7, 3, "High power microwave oven", "Microwave Oven", 89.99m, 100 },
                    { 8, 3, "Smoothie blender", "Blender", 49.99m, 150 },
                    { 9, 4, "Classic novel by F. Scott Fitzgerald", "The Great Gatsby", 10.99m, 500 },
                    { 10, 4, "Dystopian novel by George Orwell", "1984", 12.99m, 450 },
                    { 11, 5, "Remote controlled car", "Toy Car", 29.99m, 200 },
                    { 12, 5, "Set of colorful building blocks", "Building Blocks", 19.99m, 400 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderId", "ProductId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 999.99m, 1 },
                    { 1, 3, 199.99m, 2 },
                    { 2, 2, 1499.99m, 1 },
                    { 2, 4, 19.99m, 3 },
                    { 3, 7, 89.99m, 1 },
                    { 3, 8, 49.99m, 2 },
                    { 4, 9, 10.99m, 2 },
                    { 4, 10, 12.99m, 1 },
                    { 5, 11, 29.99m, 1 },
                    { 5, 12, 19.99m, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 5, 11 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 5, 12 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);
        }
    }
}
