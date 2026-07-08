# Technical Specification Document

This document provides a detailed overview of the backend infrastructure, database design, and architectural decisions made for the **Personal Blog & Portfolio Platform**.

---

## Architecture & Design Patterns

The project is engineered following **Clean Architecture** principles to separate core business logic from infrastructure dependencies.

### 1. Separation of Concerns & Layers
- **Core (Domain & Application):** Contains pure business entities, interfaces, and CQRS handlers (MediatR).
- **Infrastructure:** Handles data access (EF Core), external cloud services (Amazon S3), and logging implementations.
- **Presentation (Web API):** Exposes RESTful endpoints, manages authentication pipelines, and injects dependencies via `Program.cs`.

### 2. Design Patterns Implemented
- **CQRS Pattern:** Orchestrated via `MediatR` to separate write operations (Commands) from read operations (Queries).
- **Unit of Work & Repository Pattern:** Abstracts data access, shielding the core layers from direct EF Core dependencies and ensuring atomicity.
- **Chain of Responsibility (Pipeline):** Utilizes custom ASP.NET Core middlewares (`ErrorHandlingMiddleware`) for global exception handling and request telemetry.

---

## Database Architecture (EF Core & SQL Server)

The database layer utilizes **Entity Framework Core** with a **Code-First** approach. Database tables are highly organized into logical relational **Schemas** using Fluent API configurations:

### Database Schemas & Relations
* **`Account` Schema:**
    * `Users`: Managed with custom configurations (`UserName` and `Email` are indexed as unique). It has a Many-to-One relationship with `Roles` and a Cascade-Delete relation with `Posts`.
* **`Post` Schema:**
    * `Posts`: Configured with specific string lengths (`Title: 200`, `Summary: 500`). Has a Cascade-Delete relationship with `PostContents` and a Restrict-Delete relationship with `Comments` and `Author`.
    * `Comments`: Features a **Self-Referencing (1-to-Many) relationship** (`ParentComment` $\rightarrow$ `Replies`) configured with `DeleteBehavior.NoAction` to safely support threaded nested replies. A composite index `IX_PostId_ParentId` is added for high-performance query optimization.
* **`Info` Schema:**
    * `PersonalInformation`: Stores bio and metrics (`AboutMe: 1500 max`). Maintained with a Cascade-Delete relation to `ContactInfo`.
    * `ContactInfo`: Holds dynamic contact channels (e.g., social links, emails) linked dynamically via `ContactWayType`.
* **`Project` Schema:**
    * `Projects`: Stores personal and commercial work history including metadata like `Owner`, `StartDate`, and nullable `EndDate`.

---

## Infrastructure & Service Integrations

### 1. Cloud Object Storage (Amazon S3)
File uploads and static assets are handled via the **AWS SDK (`IAmazonS3`)**. The client is dynamically registered as a Singleton in `Program.cs` utilizing customized options from `appsettings.json`:
- Overridden `ServiceURL` to match private cloud object storage providers.
- Enabled `ForcePathStyle` for specific S3 endpoint compatibility.

### 2. Structured Logging (Serilog)
Advanced logging is implemented using **Serilog**, decoupled from standard Microsoft abstractions.
- **Sink:** Configured to log directly into local rolling text files (`Logs/log-.txt`).
- **Rolling Strategy:** `Day` interval with a limit of 10 retained files to optimize storage.
- **Configuration:** Handled natively via `appsettings.json` under the `"Serilog"` key with contextual enrichment (`Enrich.FromLogContext()`).

### 3. Authentication & Security
- Secure token-based access via **JWT Bearer Authentication**.
- Parameters validated strictly in the middleware: `ValidateIssuer`, `ValidateAudience`, `ValidateLifetime`, and cryptographic signing validation using `SymmetricSecurityKey`.

### 4. API Exploration & Tooling
- Integrated **Swagger/OpenAPI UI** (`AddSwaggerGen`) along with .NET 9's local OpenApi features (`AddOpenApi`) for interactive API testing during development environments.
- Automated migrations applied dynamically on development startup via custom extension (`app.MigrateDatabase()`).

---

## Configuration Setup (`appsettings.json`)

To run the infrastructure locally or in production, ensure your environment variables or local JSON settings resemble the following schema:

```json
{
  "ConnectionStrings": {
    "PersonalBlogConnection": "Your_SQL_Server_Connection_String"
  },
  "Settings": {
    "Jwt": {
      "Issuer": "Your_Issuer_URI",
      "Audience": "Your_Audience_URI",
      "Key": "Your_Super_Secret_Symmetric_Key_Minimum_256_Bit"
    },
    "S3Storage": {
      "Endpoint": "Storage_Endpoint_Url",
      "BucketName": "Bucket_Name",
      "AccessKey": "Access_Key",
      "SecretKey": "Secret_Key",
      "UseSSL": true
    }
  }
}
