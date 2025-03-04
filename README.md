# E-Commerce Platform Project

## Overview

This is a simple console-based E-Commerce Platform application built with **C#** and **Entity Framework Core**. The project simulates a basic e-commerce system where users can manage products, customers, and categories, as well as place and view orders.

## Features

The application provides the following functionalities:

### Main Menu Options:
1. **Product Management**
   - Add a new product
   - Update an existing product
   - Delete a product
   - View all products
   - Exit to the main menu

2. **Customer Management**
   - Add a new customer
   - Update an existing customer
   - Delete a customer
   - View customer details
   - View a customer's orders

3. **Category Management**
   - Add a new category
   - Update an existing category
   - Delete a category
   - View all products in a category
   - View all categories

4. **Place an Order**
   - Create an order by selecting a customer and adding products to the order.

5. **View Order History**
   - Display the history of all orders.

6. **Exit**
   - Exit the application.

## Project Structure

The project is organized into the following folders:

- **Dependencies**: Additional datatypes used across the application.
- **Context**: Configures the database context for Entity Framework Core.
- **Migrations**: Auto-generated migration files for database schema updates.
- **Models**: Defines the core entities of the application.
- **Models Configuration**: Contains Fluent API configurations for database mappings.
- **Repository**: Implements the repository pattern for data access.
- **UI Pages**: Handles the user interface for each feature in the main menu.

## Technologies Used

- **C#** (Console Application)
- **Entity Framework Core**
- **SQL Server** (for database)

## Getting Started

### Prerequisites

- .NET 6 SDK or higher
- SQL Server (or any other database supported by EF Core)

### Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/ahmedashraf0001/E-Commerce-Platform-Project.git
   cd E-Commerce-Platform-Project
   ```
2. Configure the database connection in the application.
3. Apply migrations to set up the database:
   ```bash
   dotnet ef database update
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
### Contributing

 - Contributions are welcome! Please open an issue or submit a pull request if you have suggestions or improvements.
