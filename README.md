# 📦 ASP.NET Core Web API — EF Core, Repository Pattern, CQRS, MediatR

This project is a modern **ASP.NET Core Web API** built using clean architectural principles and a two-layer solution structure.  
It demonstrates core backend development skills including:

- EF Core Code-First  
- Repository Pattern  
- CQRS with MediatR  
- DTO-based API design  
- Manual entity/DTO mapping  
- Layered architecture with separation of concerns  

Designed as a **portfolio project** to showcase real-world .NET backend engineering practices.

---

## 🚀 Features

### ✔ ASP.NET Core Web API  
RESTful API following clean coding principles and proper separation of concerns.

### ✔ Entity Framework Core (Code-First)  
- Code-first migrations  
- Strongly typed DbContext  
- Simple and clear domain model  
- Navigation property demonstration  

### ✔ Repository Pattern  
Abstracts data access logic into a clean, reusable layer.

### ✔ CQRS Pattern with MediatR  
- Queries handle read operations  
- Commands handle write operations  
- No business logic inside controllers  
- Clean and testable request/response workflow

### ✔ Manual Mapping (No AutoMapper)  
Entity ↔ DTO conversion is handled manually using lightweight mapper classes.

### ✔ Two-Layer Architecture  
    Presentation Layer → Web API Project  
    Data Layer         → Class Library Project

### ✔ DTOs for Encapsulation  
Prevents over-posting, hides database structure, and keeps your API contract stable.

---

## 🏗️ Technologies Used

| Technology | Purpose |
|-----------|---------|
| ASP.NET Core 8 Web API | API framework |
| Entity Framework Core | ORM + Migrations |
| Repository Pattern | Data access abstraction |
| MediatR | CQRS implementation |
| Manual Mapping | DTO ↔ Entity conversion |
| SQL Server / SQLite | Database |
| Data Annotations | Input validation |
| Dependency Injection | Loose coupling |

---

## 📚 Domain Model

A simple Product–Category relation, ideal for demonstrating EF Core and CQRS.

    Category 1 ---- * Product

### Category  
- Id  
- Name  

### Product  
- Id  
- Name  
- Price  
- Description  
- CategoryId (FK)

---

## 📁 Project Structure

    YourSolution/
    │
    ├── YourApi/
    │   ├── Controllers/
    │   ├── CQRS/
    │   │   ├── Products/
    │   │   │   ├── Commands/
    │   │   │   └── Queries/
    │   ├── DTOs/
    │   ├── Mappers/
    │   └── Program.cs
    │
    └── YourData/
        ├── Entities/
        ├── Repositories/
        │   ├── Interfaces/
        │   └── Implementations/
        ├── ApplicationDbContext.cs
        └── Migrations/

---

## 🧪 Example Endpoints

### GET /api/products  
Retrieves all products using `GetAllProductsQuery` (via MediatR).

### POST /api/products  
Creates a new product using `CreateProductCommand` and manual mapping.

### PUT /api/products/{id}  
Updates a product using `UpdateProductCommand`.

### DELETE /api/products/{id}  
Deletes a product using `DeleteProductCommand`.

---

## 🧑‍💻 Author  
**Mady**  
🚀 ASP.NET Core Backend Developer  
📌 Focused on building clean, scalable, and maintainable APIs  
🔗 LinkedIn: https://linkedin.com/in/yourprofile
