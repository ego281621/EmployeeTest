
# EmployeeAPI

EmployeeAPI is a RESTful API for managing employee records. It allows you to perform CRUD operations on employee data stored in a relational database.

## Project Structure

The project follows a standard structure for an ASP.NET Core Web API project with additional components for data access and testing:

EmployeeAPI (Solution)
├── EmployeeAPI (Project - ASP.NET Core Web API)
│ ├── Controllers
│ │ └── EmployeesController.cs
│ ├── Models
│ │ └── Employee.cs
│ ├── Data
│ │ ├── EmployeeRepository.cs
│ │ └── IEmployeeRepository.cs
│ ├── Profiles
│ │ └── EmployeeProfile.cs
│ └── appsettings.json
├── EmployeeAPI.Data (Class Library - Data Access)
│ ├── Employee.cs
│ └── EmployeeDbContext.cs
└── EmployeeAPI.Tests (Test Project)
└── EmployeesControllerTests.cs

## Getting Started - Update Database

```
-- Create DATABASE in you're local in SQL Server Management Studio
 Database Name: EmployeeDB

-- Run this script in your local SQL Server Management Studio
-- Create the "Employee" table

CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[MiddleName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
  CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)

-- Insert sample data into the "Employee" table

INSERT INTO Employee
SELECT 'Test Name 1', 'Test Name 1', 'Test Name 1' UNION ALL
SELECT 'Test Name 2', 'Test Name 2', 'Test Name 2' UNION ALL
SELECT 'Test Name 3', 'Test Name 3', 'Test Name 3'

### Configuration

- Update the connection string in `appsettings.json` to point to your desired database.

### Running the API
- You could run it directly by Visual Studio once you run it it has an Swagger
![image](https://github.com/ego281621/EmployeeTest/assets/20109990/1f606bb9-9d78-4eb9-9f7c-273da14a0531)
