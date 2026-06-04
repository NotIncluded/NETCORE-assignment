# Simple CRUD Web API
A CRUD Web API is an application programming interface that allows clients to perform basic database operations through HTTP requests. CRUD stands for Create, Read, Update, and Delete, which are the four fundamental operations for managing data.

## CRUD Operations

### 1. Create
Adds a new record to the database.

- HTTP Method: `POST`
- Example: Create a new user or product.

### 2. Read
Retrieves data from the database.

- HTTP Method: `GET`
- Example: Get all products or retrieve a specific product by ID.

### 3. Update
Modifies an existing record.

- HTTP Method: `PUT` or `PATCH`
- Example: Update a user's information.

### 4. Delete
Removes a record from the database.

- HTTP Method: `DELETE`
- Example: Delete a product by ID.

## Main Components

### Controller
Handles incoming HTTP requests and returns responses.

### Model
Represents the data structure used by the application.

### Database
Stores and manages application data.

### Service Layer (Optional)
Contains business logic and acts as an intermediary between controllers and the database.

## Example API Endpoints

| Operation | HTTP Method | Endpoint |
|------------|------------|------------|
| Create | POST | `/api/products` |
| Read All | GET | `/api/products` |
| Read One | GET | `/api/products/{id}` |
| Update | PUT | `/api/products/{id}` |
| Delete | DELETE | `/api/products/{id}` |

## Benefits
- Provides a standardized way to manage data.
- Supports communication between different applications.
- Easy to integrate with web, mobile, and desktop clients.
- Promotes scalable and maintainable system design.

## Conclusion
A Simple CRUD Web API enables applications to create, retrieve, update, and delete data through HTTP requests. It is a fundamental concept in modern web development and serves as the foundation for many web and mobile applications.