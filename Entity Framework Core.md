# Entity Framework Core Basics
## Key Features
- **Cross-platform**: Works on Windows, Linux, and macOS.
- **Object-Relational Mapping (ORM)**: Maps database tables to C# classes.
- **LINQ Support**: Allows querying data using C# syntax.
- **Database Migrations**: Manages database schema changes through code.
- **Multiple Database Providers**: Supports SQL Server, MySQL, PostgreSQL, SQLite, and others.

## Main Components

### 1. DbContext
The main class that manages database connections and coordinates data operations.

### 2. Entities
C# classes that represent database tables.

### 3. DbSet
Represents a collection of entities and is used to query and save data.

### 4. Migrations
A feature that tracks and applies database schema changes.

### 5. LINQ Queries
Used to retrieve and manipulate data using C# expressions instead of raw SQL.

## Common Operations
- Create new records
- Read data from the database
- Update existing records
- Delete records
- Perform filtering, sorting, and searching

## Advantages
- Reduces the amount of SQL code needed.
- Improves developer productivity.
- Provides type-safe database access.
- Supports multiple database systems.
- Integrates seamlessly with ASP.NET Core.

## Conclusion
Entity Framework Core simplifies database development by allowing developers to interact with databases through C# objects. It improves productivity, maintainability, and compatibility across different database systems.