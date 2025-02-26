# ERP Project

This project is the backend of a modern ERP system developed using **.NET 8**. The system is designed with a focus on **scalability**, **sustainability**, and **robustness**, and is built following **Clean Architecture** principles. Design patterns like **CQRS** (Command Query Responsibility Segregation), **Repository Pattern**, and **Result Pattern** are implemented to ensure a manageable and extensible infrastructure.

## Features

- **Clean Architecture**: The project structure follows a layered architecture to ensure separation of concerns and sustainability.
- **CQRS**: Using separate models for write operations (commands) and read operations (queries) improves application performance and scalability.
- **Repository Pattern**: Encapsulates data access logic, abstracts data operations, and centralizes them.
- **Result Pattern**: Provides a result-oriented approach to handle success and error responses.
- **JWT Authentication**: API endpoints are secured with JWT (JSON Web Token) authentication.
- **AutoMapper**: Simplifies object-to-object mapping.
- **Entity Framework Core**: Provides data access and ORM (Object-Relational Mapping) for SQL Server.
- **FluentValidation**: Validates models and user input in a flexible way.
- **SmartEnum**: Enhances enum usage to be safer and more extensible.

## Technologies Used

- **.NET 8**
- **MediatR**: Used to facilitate communication between components in a loosely coupled manner.
- **Entity Framework Core**: Used for data access and ORM operations.
- **AutoMapper**: Used for object mapping.
- **SmartEnum**: Provides safer and more extensible enum management.
- **FluentValidation**: Used for model and user input validation.
- **JWT Authentication**: Secures API endpoints.

## Configuration

You can configure the application via the **appsettings.json** file or environment variables.

- **JWT Authentication**: Configure the JWT secret key and expiration time in the **appsettings.json** file or environment variables.
- **Database Connection**: Configure the SQL Server connection string in the **appsettings.json** file.

## Libraries and Packages Used

- **Microsoft.Extensions.Options** 8.0.2
- **FluentValidation** 11.9.0
- **MediatR** 12.2.0
- **Microsoft.AspNetCore.Identity** 2.2.0
- **TS.Result** 8.0.6
- **Ardalis.SmartEnum** 8.0.0
- **TS.EntityFrameworkCore.GenericRepository** 8.0.0
- **Microsoft.AspNetCore.Authentication.JwtBearer** 8.0.4
- **Microsoft.EntityFrameworkCore.SqlServer** 8.0.4
- **Scrutor** 4.2.2
- **AutoMapper** 13.0.1

## License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.
