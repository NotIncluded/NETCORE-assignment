# Task Management API

A simple, asynchronous RESTful Web API built with **.NET 8**, **Entity Framework Core (SQLite)**, and **JWT Authentication**.

## Features
- **CRUD Operations**: Manage tasks asynchronously via `TasksController`.
- **SQLite Database**: Lightweight, file-based database configured via EF Core Migrations.
- **JWT Authorization**: Secured endpoints using JSON Web Tokens
- **Swagger UI**: Interactive API documentation and testing interface natively integrated.

## How to Run the Project

1. Open a terminal (e.g., PowerShell, Command Prompt, or VS Code Terminal) and navigate to the root directory of your project (where the `.csproj` file is located).
2. Restore the required NuGet packages and build the project:
   ```bash
   dotnet build
3. Start the local development server:
    ```bash
   dotnet run
4. Look at the terminal output for the exact listening port (usually http://localhost:5094).
5. Open your web browser and navigate to the Swagger UI: http://localhost:5094/swagger

# How to Authenticate and Test in Swagger

Because the TasksController is protected by the [Authorize] attribute, you cannot access its endpoints without a valid JSON Web Token (JWT). Follow these steps to unlock the API:

## Step 1: Generate a Token
1. On the Swagger UI page, scroll down to the POST /api/Auth/login endpoint.
2. Click the Try it out button, then click Execute (you do not need to provide any input parameters).
3. Scroll down to the Server response body. You will see a JSON object containing a long, random-looking text string.
4. Copy the token string (make sure not to include the quotation marks ").

## Step 2: Authorize Swagger
1. Scroll back to the very top of the Swagger page.
2. Click the green Authorize button (with the padlock icon).
3. A dialog box will appear. In the Value text box under the Bearer section, paste your copied token.
4. Click the Authorize button, and then click Close.

## Step 3: Test the API
You will now notice that the small padlock icons next to the Tasks endpoints are "locked" / closed. This means Swagger is now automatically sending your JWT in the headers.

1. You can now freely test your CRUD endpoints:
2. POST /api/Tasks: Create a new task.
3. GET /api/Tasks: Fetch all tasks from SQLite.
4. GET /api/Tasks/{id}: Fetch a specific task.
5. PUT /api/Tasks/{id}: Update an existing task.
6. DELETE /api/Tasks/{id}: Remove a task.