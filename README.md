# 🚗 Vehicle Inspection Appointment System

A full-stack web application that lets **vehicle owners** book technical inspection appointments online and lets **inspection centers** manage their daily schedules — all through a secure, role-based platform.

---

## ✨ Features

- **Role-based access** for Admin, Center Operators, and Vehicle Owners
- **Vehicle management** — register and manage vehicle profiles
- **Smart appointment booking** against available time slots
- **Time-slot management** with real-time capacity tracking
- **Technical inspection records** with pass/fail results
- **Geographic hierarchy** — centers organized by city and province
- **Redis caching** for frequently accessed data
- **Centralized error handling & request validation**
- **Fully documented REST API** via Swagger/OpenAPI

---

## 🛠️ Tech Stack

| Layer | Technology |
|-------|-----------|
| Backend | C# · ASP.NET Core Web API (.NET 9) |
| Architecture | Clean Architecture · DDD-lite |
| Data Access | EF Core · SQL Server · Fluent API · Migrations |
| Patterns | Repository + Unit of Work · Result Pattern |
| Caching | Redis |
| Docs | Swagger / OpenAPI |

---

## 🗂️ Project Structure

```
VehicleInspectionAppointmentSystem.Domain          # Entities, interfaces, enums, domain exceptions, DTOs
VehicleInspectionAppointmentSystem.Business        # Business services, logic, Redis service, request DTOs
VehicleInspectionAppointmentSystem.RepositoryLayer # Generic repository, unit of work, EF repositories
VehicleInspectionAppointmentSystem.Infrastructure  # DbContext, EF configurations, migrations
VehicleInspectionAppointmentSystem.WebApi          # Controllers, middleware, filters, REST API
VehicleInspectionAppointmentSystem.Presentation    # Console entry point
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server)
- [Redis](https://redis.io/)

### Setup

1. **Clone** the repository
   ```bash
   git clone <your-repo-url>
   ```

2. **Configure secrets** — the database connection is stored in **User Secrets**
   ```bash
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=YOUR_SERVER;Database=VehicleInspectionDB;Trusted_Connection=true;TrustServerCertificate=True"
   dotnet user-secrets set "ConnectionStrings:Redis" "localhost:6379"
   ```

3. **Apply migrations** to build the database
   ```bash
   dotnet ef database update
   ```

4. **Run** the Web API
   ```bash
   dotnet run --project VehicleInspectionAppointmentSystem.WebApi
   ```

5. **Explore** the API at `https://localhost:<port>/swagger`

---

## 📌 Notes

- Database schema & constraints are configured using **EF Core Fluent API**.
- Includes **seed data** for provinces, cities, centers, users, vehicles, time slots, and appointments.
- Sensitive configuration is kept out of version control via **.NET User Secrets**.
