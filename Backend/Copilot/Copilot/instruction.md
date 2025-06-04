# E-commerce Product API Implementation Instructions

## Overview
Create a RESTful API with CRUD endpoints for managing products in an e-commerce application, using the provided "Divine Shop" image as a reference. The API will use an in-memory database for data persistence during the application lifecycle.

## Requirements

### 1. Product Image Analysis
- Analyze the provided `divine-shop-reference.jpg` image in the project's `wwwroot/images/` directory
- Identify the key product attributes visible in the image (such as name, price, discount information, etc.)
- Design a Product model based on the observed properties in the image

### 2. Data Access
- Implement an in-memory database using Entity Framework Core's InMemory provider
- Create a DbContext class with a DbSet for products
- Add seed data that reflects products similar to those shown in the reference image

### 3. API Controllers
Implement a ProductsController with the following endpoints:

#### GET /api/products
- Return all products
- Support the filtering options visible in the UI (based on the categories and price ranges shown in the image)
- Support sorting options as suggested by the UI elements in the image
- Implement pagination similar to what might be used in the reference application

#### GET /api/products/{id}
- Return a specific product by ID
- Return 404 if product not found

#### POST /api/products
- Create a new product
- Validate the request data
- Return 201 Created with the product data and location header

#### PUT /api/products/{id}
- Update an existing product
- Return 404 if product not found
- Return 200 OK with updated product data

#### DELETE /api/products/{id}
- Delete a product by ID
- Return 204 No Content on success
- Return 404 if product not found

### 4. Validation
- Implement validations appropriate for the product properties identified in the image
- Ensure all required fields are properly validated

### 5. Dependency Injection
- Register the DbContext as a service
- Consider implementing a repository pattern or service layer

### 6. Documentation
- Configure Swagger/OpenAPI documentation
- Add appropriate XML comments to controllers and models

## Implementation Steps

1. **Set up the project**:
   - Use the existing .NET 8 Web API project
   - Add Entity Framework Core InMemory package
   - Create a directory for the reference image if it doesn't exist

2. **Analyze the reference image**:
   - Identify the product attributes shown in the image
   - Determine filtering and sorting options from the UI elements
   - Design the data model based on this analysis

3. **Create the Product model**:
   - Define the Product class with properties that match the information shown in the image
   - Include any additional properties necessary for the API functionality

4. **Set up DbContext**:
   - Create ApplicationDbContext class inheriting from DbContext
   - Add DbSet<Product> for products
   - Configure the InMemory database in Program.cs
   - Seed initial data based on products visible in the reference image

5. **Create the Repository layer (optional but recommended)**:
   - Define an IProductRepository interface
   - Implement ProductRepository class

6. **Implement the ProductsController**:
   - Create all required CRUD endpoints
   - Implement filtering and sorting options observed in the image
   - Add proper status codes and responses

7. **Add validation**:
   - Use Data Annotations or Fluent Validation
   - Implement proper error handling

8. **Configure Swagger documentation**:
   - Ensure all endpoints are properly documented

## Testing
- Test all endpoints using Swagger UI
- Verify all CRUD operations work correctly
- Test the filtering and sorting features that match the reference UI

## Expected Result
A fully functional RESTful API that can:
- Display a list of products with filtering and sorting options similar to those in the reference image
- Show details of a specific product
- Add new products
- Update existing products
- Delete products

The API should accurately represent the product information structure shown in the Divine Shop reference image, without requiring pre-defined data structures in this instruction file.