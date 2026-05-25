# Task Tracker Web API
A simple Task Tracker REST API built with ASP.NET Core Web API, following Clean Architecture principles.
It supports full CRUD operations for managing task items.

⚙️ Design 


🚀 Features
| Method | Endpoint | Method | Endpoint         | Description   | Request Body |
|--------|-------------------|------------------|---------------|--------------|
| GET    | /api/tasks        | Get all tasks     | ❌           | List of tasks|
| GET    | /api/tasks/{id}   | Get task by ID    | ❌           | Single task  |
| POST   | /api/tasks        | Create new task   | ✅ Task DTO  | Created task |
| PUT    | /api/tasks/{id}   | Update task       | ✅ Task DTO  | No content   |
| DELETE | /api/tasks/{id}   | Delete task       | ❌           | No content   |
- Layered architecture (API / Application / Domain / Infrastructure)
- Entity Framework Core integration
- SQLite (or SQL Server configurable)

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

