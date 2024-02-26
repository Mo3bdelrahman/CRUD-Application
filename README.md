# CRUD Application using MVC, EF Core, and SQL Server

This CRUD (Create, Read, Update, Delete) application is built using ASP.NET Core MVC, Entity Framework Core, SQL Server, dependency injection, and repository architecture.

## Prerequisites

- Visual Studio (or Visual Studio Code)
- .NET Core SDK
- SQL Server

## Installation

1. Clone the repository.
2. Open the solution file in Visual Studio.
3. Configure the database connection string in `appsettings.json`.
4. Build and run the application.

## Usage

Once the application is running, you can perform the following operations:

- **Create**: Add new records to the database.
- **Read**: View existing records from the database.
- **Update**: Modify existing records in the database.
- **Delete**: Remove records from the database.

## Features

- Create, read, update, and delete operations for managing data.
- MVC architecture for separating concerns and improving maintainability.
- Entity Framework Core for data access and ORM (Object-Relational Mapping).
- Dependency injection for managing application dependencies.
- Repository pattern for encapsulating data access logic.

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Dependency Injection

## Project Structure

- **Controllers**: Contains MVC controllers to handle HTTP requests.
- **Models**: Defines entity classes representing database tables.
- **Views**: Contains Razor views for displaying UI and user input forms.
- **View Models**: Contains view model classes for data presentation and manipulation.
- **Data**: Includes DbContext class for interacting with the database.
- **Repositories**: Implements repository classes for CRUD operations.



