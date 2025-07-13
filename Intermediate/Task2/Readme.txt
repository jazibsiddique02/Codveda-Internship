#  Mini Product Catalog – ASP.NET Core MVC Application

This is a CRUD-based ASP.NET Core MVC web application developed as part of an internship assignment. It demonstrates the use of **MVC architecture**, **Repository & Unit of Work patterns**, **custom middleware**,**Dependency Injection** and **Serilog** for logging.

---

##  Features

-  Create, Read, Update, Delete (CRUD) operations for products
-  N-Tier Architecture with separation of concerns
-  Repository Pattern:
  - Generic `IRepository<T>` for common data access
  - `IProductRepository` for product-specific operations (`Update`)
-  Unit of Work Pattern:
  - Centralized `Save()` method using `ApplicationDbContext`
  - `IProductRepository` instance which includes all CRUD operations related to product model.
  - `UnitOfWork` is registered with DI container
-  Razor Views for dynamic UI rendering
-  Custom Middleware for request timing logs
-  Logging using **Serilog**:
  - Logs meaningful navigation requests to console and log file
  - Ignores static file requests (e.g. `.css`, `.js`) for cleaner logs

---

## Project Structure

Task 2/
│
├── MiniProductCatalog/ --> Main startup project (Controllers, Views, Middleware)
│ ├── Controllers/
│ ├── Views/
│ ├── Middlewares/
│ ├── wwwroot/
│ └── Program.cs
│
├── MiniProductCatalog.Models/ --> Contains only model classes
│ └── Product.cs
│
└── MiniProductCatalog.DataAccess/ --> Data layer (Repositories, DbContext, Migrations)
├── Data/
│ └── ApplicationDbContext.cs
├── Repository/
│ ├── Interface/
│ │ ├── IRepository.cs
│ │ └── IProductRepository.cs
│ │	└── IUnitOfWork.cs
│ ├── ProductRepository.cs
│ ├── UnitOfWork.cs
│ ├── Repository.cs
└── Migrations/