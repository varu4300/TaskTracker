# Task Tracker Web API
A simple Task Tracker REST API built with ASP.NET Core Web API, following Clean Architecture principles.
It supports full CRUD operations for managing task items.

⚙️ To run project
1) Ensure you're running .NET 10 (no mention of verions to use, defaulted to my workspace version)
2) You will need to run migrations with following command from root of project (where .sln file is)
```
dotnet ef migrations add InitialCreate \
--project TaskTracker.Infrastructure \
--startup-project TaskTracker.Api
```
3) Run the project
4) Navigate to http://localhost:5149 (Swagger should open up for easy testing)

Assumptions Made
1) Status field is case sensitive
2) Returning error message within the response
3) Kept to a standard response
```
{
  "result": [],
  "message": "",
  "statusCode": 200
}
```
4) Validation is performed while request is made to prevent extra work


🚀 Features
- Create task items
- Retrieve all tasks 
- Retrieve task by ID
- Update task items
- Delete task items
- Layered architecture (API / Application / Domain / Infrastructure)
- Entity Framework Core integration
- SQLite

🏗️ Architecture
TaskTracker
├── TaskTracker.Api (Controllers, Models, etc...)
├── TaskTracker.Application (Business Logic)
├── TaskTracker.Domain ()
├── TaskTracker.Infrastructure
├── TaskTracker.Tests

🧱 Tech Stack
- .NET 10 Web API
- C#
- Entity Framework Core
- SQLite
- Dependency Injection
- RESTful API principles
- Swagger

