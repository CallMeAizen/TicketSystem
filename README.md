# Ticket System API Project

## Overview

The system consists of two tables: `Ticket` and `User`. Each user is associated with one ticket, and the system includes features for creating, retrieving, and managing tickets. It also includes identity management for admin users with JWT token authentication.

## Features

- **Create Tickets**: Create tickets associated with user mobile numbers. Each user has only one ticket. Ticket images are saved as JPEG files from HTML strings.
- **Retrieve Tickets**: Get all tickets in descending order by ticket number.
- **Get User Ticket Details**: Retrieve ticket details by user mobile number.
- **Admin Authentication**: Register and login for admin users using JWT tokens.
- **Swagger Documentation**: Provides interactive API documentation for easy testing and exploration.

## Technologies

- **ASP.NET Core API (.NET 8)**: Framework for building the API.
- **Entity Framework Core**: ORM for database interactions.
- **SQL Server**: Database for storing ticket and user data.
- **Repository Pattern**: Architecture pattern used in the project.

## Packages Used

- **ASP.NET Core Web API**:
  - `Microsoft.AspNetCore.App`

- **Entity Framework Core**:
  - `Microsoft.EntityFrameworkCore.SqlServer` (Version 8.0.0)
  - `Microsoft.EntityFrameworkCore.Tools` (Version 8.0.0)

- **JWT Authentication**:
  - `Microsoft.AspNetCore.Authentication.JwtBearer` (Version 8.0.0)
  - `System.IdentityModel.Tokens.Jwt` (Version 8.0.0)

- **Swagger Documentation**:
  - `Swashbuckle.AspNetCore` (Version 8.0.0)

