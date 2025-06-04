The backend API is available at `https://localhost:7194` with the following endpoints:

- **GET /api/products** - Retrieve all products with optional filtering and pagination
- **GET /api/products/{id}** - Retrieve a specific product by ID
- **POST /api/products** - Create a new product
- **PUT /api/products/{id}** - Update an existing product
- **DELETE /api/products/{id}** - Delete a product

### GET /api/products Query Parameters

The GET products endpoint supports the following optional query parameters for filtering, sorting, and pagination:

- **Category** (string) - Filter products by category name
- **MinPrice** (number) - Filter products by minimum price
- **MaxPrice** (number) - Filter products by maximum price  
- **OnSale** (boolean) - Filter products by sale status
- **Featured** (boolean) - Filter products by featured status
- **SortBy** (string) - Field to sort by (e.g., "price", "name", "rating")
- **SortDesc** (boolean) - Sort in descending order if true
- **Page** (integer) - Page number, starting from 1
- **PageSize** (integer) - Number of items per page (default: 10)

**Example URL**: `https://localhost:7194/api/Products?Page=1&PageSize=10&Category=Electronics&MinPrice=50&MaxPrice=500&OnSale=true&SortBy=price&SortDesc=false`