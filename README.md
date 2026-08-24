# StoreApp — ASP.NET Core MVC Store

A full-stack store application built with ASP.NET Core MVC. The project demonstrates a layered .NET architecture, server-rendered storefront pages, session-based shopping cart behavior, order processing, ASP.NET Core Identity, and a role-protected administration area.

> **Project status:** Feature-complete for its original educational and portfolio scope. It is a demonstration application, not a production-ready commerce platform.

## Features

### Storefront

- Product catalog with details, category filtering, search, and pagination
- Showcase products on the home page
- Session-based shopping cart
- Authenticated checkout and order creation
- Registration, login, logout, and access-denied flows
- Turkish request localization
- JSON product endpoint at `GET /api/products`

### Administration

- Role-protected admin dashboard
- Product create, update, delete, image upload, and showcase management
- Category overview
- Order listing and completion workflow
- User creation, editing, deletion, password reset, and role assignment
- Reusable view components, tag helpers, partial views, and TempData notifications

## Architecture

The solution separates domain models, data access, business logic, API presentation, and the MVC host into individual projects.

```text
Store/
├── Entities/       Domain models, DTOs, and request parameters
├── Repositories/   EF Core context, configurations, repositories, and contracts
├── Services/       Business services and service contracts
├── Presentation/   API controllers
└── StoreApp/       MVC/Razor UI, Identity, admin area, session, and application host
```

The main request flow is:

```text
Controller → Service → Repository → Entity Framework Core → SQLite
```

Dependency injection is used throughout the application, while repository and service manager abstractions provide a single entry point to their respective layers.

## Technology Stack

- .NET 9 and C#
- ASP.NET Core MVC and Razor Pages
- Entity Framework Core 9
- SQLite
- ASP.NET Core Identity
- AutoMapper
- Bootstrap 5
- JavaScript and jQuery
- Font Awesome

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Git

SQLite is used locally, so a separate database server is not required.

### Installation

```bash
git clone https://github.com/cembora19/MVC_Project.git
cd MVC_Project/Store
dotnet restore Store.sln
dotnet run --project StoreApp/StoreApp.csproj
```

The HTTP launch profile serves the application at:

```text
http://localhost:5279
```

The application checks and applies pending EF Core migrations during startup. The repository also includes a local SQLite database and seeded sample categories and products.

## Admin Access

The application creates a development administrator on startup when one does not already exist.

```text
Username: Admin
Password: Admin+123456
Admin area: /admin
```

These credentials are included only to make the demonstration project easy to evaluate. They must be removed or replaced with configuration-based secrets before any deployment.

## Useful Routes

| Route | Purpose | Access |
| --- | --- | --- |
| `/` | Storefront home page | Public |
| `/product` | Product catalog | Public |
| `/cart` | Shopping cart | Public |
| `/order/checkout` | Checkout | Authenticated user |
| `/account/login` | Sign in | Public |
| `/admin` | Administration dashboard | Admin role |
| `/api/products` | Product list as JSON | Public |

## Database

The default connection string is defined in `Store/StoreApp/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=ProductDb.db"
  }
}
```

To use another SQLite file without editing the committed settings, override the connection string with an environment variable:

```bash
ConnectionStrings__DefaultConnection="Data Source=/path/to/store.db" \
  dotnet run --project StoreApp/StoreApp.csproj
```

## Build Verification

```bash
cd Store
dotnet build Store.sln --configuration Release
```

The solution currently builds successfully on .NET 9. There is no automated test project yet; the repository should therefore be treated as a portfolio/learning project rather than a production release.

## Current Limitations

- Checkout records an order but does not integrate with a real payment provider.
- Product images are stored in the local `wwwroot/images` directory.
- SQLite and in-memory session state are intended for local demonstration.
- Automated unit and integration tests are not included.
- Development admin credentials and Identity password rules require hardening before deployment.
- Several nullable-reference and async warnings remain to be cleaned up.

## License

No license has been specified. All rights are reserved by the repository owner.
