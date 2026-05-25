# Task Tracker Web API
A simple Task Tracker REST API built with ASP.NET Core Web API, following Clean Architecture principles.
It supports full CRUD operations for managing task items.

⚙️ To run project
1) Ensure you're running .NET 10 (no mention of verions to use, defaulted to my workspace version)
2) You will need to run migrations with following command from root of project (where .sln file is). Already created the migrations, but if needed to run again for some reason the following would be the command:
```
dotnet ef migrations add InitialCreate \
--project TaskTracker.Infrastructure \
--startup-project TaskTracker.Api
```
3) Run the project
4) Navigate to http://localhost:5149 (Swagger should open up for easy testing)

Assumptions Made
1) Status field is case sensitive
2) Returning error message within the response as a string separated by the "," delimiter (ex. "Message 1, Message 2, ect...")
3) Kept to a standard response
```
{
  "result": [],
  "message": "",
  "statusCode": 200
}
```
4) Validation is performed before request execution utilizing a service filter and leveraging Fluent Validations
5) Since the task description did not include the format of endpoints the following would be the endpoints:
  -  GET PUT POST http://localhost:5149/api/tasks
  -  GET DELETE http://localhost:5149/api/tasks/{id}
5) Adding logging for tracing source of error by tag system "[LogLevel][ClassName][Method]: {{message}}"


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
```
├── TaskTracker.Api (Controllers, Models, etc...)
├── TaskTracker.Application (Business Logic)
├── TaskTracker.Domain
├── TaskTracker.Infrastructure (Infrastructure)
├── TaskTracker.Tests (Unit tests)
```

🧱 Tech Stack
- .NET 10 Web API
- C#
- Entity Framework Core
- SQLite
- Dependency Injection
- RESTful API principles
- Swagger

