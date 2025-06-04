# Product Management UI Instructions

This Angular project implements a product management interface that mimics the layout and design shown in the reference image (available at `src/assets/product-ui-reference.png`). The application follows modern responsive web design practices and utilizes Angular's component-based architecture to integrate with a backend API.

## API Integration Details

The application should integrate with the following backend API endpoints:

- **GET /api/products** - Retrieve all products
- **GET /api/products/{id}** - Retrieve a specific product by ID
- **POST /api/products** - Create a new product
- **PUT /api/products/{id}** - Update an existing product
- **DELETE /api/products/{id}** - Delete a product

**Base API URL**: `https://localhost:7194`

### API Integration Implementation

Create a product service (`product.service.ts`) that handles all API communication:

```typescript
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private baseUrl = 'https://localhost:7194/api/products';

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl)
      .pipe(
        retry(1),
        catchError(this.handleError)
      );
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.baseUrl}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  createProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(this.baseUrl, product)
      .pipe(
        catchError(this.handleError)
      );
  }

  updateProduct(id: number, product: Product): Observable<Product> {
    return this.http.put<Product>(`${this.baseUrl}/${id}`, product)
      .pipe(
        catchError(this.handleError)
      );
  }

  deleteProduct(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Client-side error
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.error(errorMessage);
    return throwError(() => new Error(errorMessage));
  }
}

## Project Structure

The UI should include the following main components:

- **Header**: With logo, search functionality, user menu, and navigation links
- **Product Listing**: Grid layout displaying product cards with images, names, and prices
- **Category/Filter Panel**: Left sidebar or top bar for filtering products
- **Pagination Controls**: For navigating through product pages
- **Product Management Forms**: For adding and editing products

## Styling Guidelines

- **Color Palette**:
  - Primary Blue: `#1976D2` (Used for buttons, header)
  - Secondary Blue: `#2196F3` (Used for highlights, accents)
  - Text Black: `#000` (Main content)
  - Text Gray: `#444` (Secondary text)
  - Background Gray: `#f9f9f9` (Page background)
  - White: `#fff` (Cards, content areas)
  - Discount Red: `#c00` (Used for sales, discounts)
  - Success Green: `#4CAF50` (For success messages)

- **Typography**:
  - Font Family: Roboto, Arial, sans-serif
  - Header sizes: Main (1.5rem), Section (1.25rem), Card (1rem)
  - Body text: 0.875rem for descriptions, 1rem for important text

- **Component Styling**:
  - Cards use subtle shadows: `box-shadow: 0 1px 3px rgba(0,0,0,0.12), 0 1px 2px rgba(0,0,0,0.24)`
  - Rounded corners: `border-radius: 4px`
  - Button styling: Primary and secondary button variants
  - Badges for discounts and special tags

## Layout Structure

The layout uses CSS Grid and Flexbox for responsive design:

```scss
.products-container {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(200px, 1fr));
  gap: 1.5rem;
}

.product-card {
  display: flex;
  flex-direction: column;
  height: 100%;
}
```

Responsive breakpoints:
- Desktop: 4+ products per row
- Tablet (<992px): 3 products per row
- Mobile (<768px): 2 products per row
- Small Mobile (<576px): 1 product per row

## Components and Features

When implementing this application, create:

1. **Product Service**: Angular service for API integration with error handling
2. **Product List Component**: Main view with grid layout and pagination
3. **Product Card Component**: Individual product display with image, name, price, and discount
4. **Product Form Component**: For adding and editing products
5. **Filter/Search Components**: For filtering by category, price range, etc.
6. **Navigation Component**: Header with search and menu
7. **Shared UI Components**: Buttons, form inputs, modals, alerts

## Data Models

Create the following model files in a dedicated `models` folder:

### Product Model (`models/product.model.ts`)

```typescript
export interface Product {
  id?: number;            // Product unique identifier
  name: string;           // Product name (required)
  description?: string;   // Product description
  price: number;          // Current price (required)
  originalPrice?: number; // Original price for discount calculation
  discountPercentage?: number; // Calculated discount percentage
  imageUrl?: string;      // URL to product image
  category: string;       // Product category (required)
  inStock: boolean;       // Availability flag (required)
  tags?: string[];        // Array of product tags
  isShowcased?: boolean;  // Flag for featured products
  dateAdded?: Date;       // When the product was added
}
```

### ProductFilter Model (`models/product-filter.model.ts`)

```typescript
export interface ProductFilter {
  search?: string;
  category?: string;
  minPrice?: number;
  maxPrice?: number;
  inStockOnly?: boolean;
  sortBy?: 'name' | 'price_asc' | 'price_desc' | 'newest';
  page?: number;
  pageSize?: number;
}
```

### PaginatedResponse Model (`models/paginated-response.model.ts`)

```typescript
export interface PaginatedResponse<T> {
  items: T[];
  totalCount: number;
  pageIndex: number;
  pageSize: number;
  totalPages: number;
}
```

## Implementation Steps

Follow these steps to implement the product management UI:

### 1. Set Up Project Structure

Create the following folder structure:
```
src/
  app/
    core/              // Core module for singleton services
      services/        // Global services
      models/          // Data models
      interceptors/    // HTTP interceptors
    features/          // Feature modules
      products/        // Product management module
        components/    // Product-related components
        services/      // Product-specific services
    shared/            // Shared module
      components/      // Reusable components
      directives/      // Custom directives
      pipes/           // Custom pipes
```

### 2. Create Core Components

#### Header Component (NavbarComponent)

Create a responsive navigation header with:
- Logo
- Search functionality
- User menu (login/register)
- Shopping cart icon with counter

#### Product List Component

Implement a grid-based product listing with:
- Filterable product cards
- Pagination controls
- Support for different view modes (grid/list)

#### Product Card Component

Create a reusable product card that displays:
- Product image
- Name and brief description
- Price with discount indicator
- Action buttons (add to cart, view details)

#### Product Form Component

Implement a reactive form for product management:
- Add new product form
- Edit existing product form
- Form validation
- Image upload preview

### 3. Implement Routing

Set up Angular routing with the following routes:
```typescript
const routes: Routes = [
  { path: '', redirectTo: 'products', pathMatch: 'full' },
  { path: 'products', component: ProductListComponent },
  { path: 'products/create', component: ProductFormComponent },
  { path: 'products/:id', component: ProductDetailComponent },
  { path: 'products/:id/edit', component: ProductFormComponent },
  { path: '**', component: PageNotFoundComponent }
];
```

## Best Practices

- **Reactive Forms**: Use Angular reactive forms for product management with proper validation
- **Error Handling**: Implement proper error handling with meaningful user messages
- **Loading States**: Show loading indicators during API requests
- **Caching**: Cache product data when appropriate to reduce API calls
- **Responsive Design**: Ensure UI works well on all device sizes
- **Lazy Loading**: Implement lazy loading for feature modules
- **State Management**: Consider using NgRx for complex state management
- **Unit Testing**: Write tests for services and components
- **Accessibility**: Ensure UI is accessible with proper ARIA attributes
- **TypeScript**: Use strong typing throughout the application
- **Code Organization**: Follow Angular style guide for naming and organization

## Responsive Design Requirements

Implement these specific breakpoints to ensure the UI is fully responsive:

```scss
// Mobile styles (up to 576px)
@media (max-width: 576px) {
  .products-container {
    grid-template-columns: 1fr;
  }
  
  .header {
    flex-direction: column;
  }
  
  .search-bar {
    width: 100%;
    margin: 10px 0;
  }
}

// Tablet styles (577px to 991px)
@media (max-width: 991px) {
  .products-container {
    grid-template-columns: repeat(2, 1fr);
  }
  
  .filters {
    flex-direction: column;
  }
}

// Desktop styles (992px and above)
@media (min-width: 992px) {
  .products-container {
    grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
  }
}
```

## Image Handling

Implement image handling with these specifications:

1. **Image Display**:
   - Use background images for product cards to maintain aspect ratio
   - Apply consistent image sizing (200px height for grid view)
   - Implement lazy loading for images

2. **Image Upload** (for admin interface):
   - Allow drag-and-drop image uploads
   - Support image preview before saving
   - Provide image cropping/resizing tools
   - Implement file size and type validation

3. **Fallback Images**:
   - Use placeholder images when product images are not available
   - Implement error handling for broken image URLs

## Available Resources

The following resources are provided to help implement the UI:

1. **Reference Image**: Available at `src/assets/product-ui-reference.png`
2. **HTML/CSS Mockup**: Available in `product-ui-mockup.html` with sample styles
3. **API Documentation**: Backend API documentation is available at `https://localhost:7194/swagger`

## Additional Features to Consider

1. **Product Details View**: Detailed view for individual products
2. **User Authentication**: Secure admin access for product management
3. **Image Upload**: Allowing image uploads for products
4. **Bulk Actions**: Delete multiple products, apply bulk discounts
5. **Analytics Dashboard**: Basic stats on product views and inventory
6. **Dark Mode**: Toggle between light and dark themes
7. **Export/Import**: Allow CSV import/export of product data
8. **Drag-and-Drop Reordering**: For featured products
9. **Stock Management**: Track and update product inventory
10. **Search Autocomplete**: Suggestion dropdown as users type in the search bar

## UI Components to Implement

Based on the reference image (`src/assets/product-ui-reference.png`), implement the following UI components:

### 1. Header Section
```html
<header class="header">
  <div class="logo">Divine Shop</div>
  <div class="search-bar">
    <input type="text" placeholder="Search for products..." [(ngModel)]="searchTerm" (keyup.enter)="searchProducts()">
    <button class="search-button" (click)="searchProducts()">
      <i class="fas fa-search"></i>
    </button>
  </div>
  <div class="user-actions">
    <a href="#" class="login-link">Login / Register</a>
    <a href="#" class="cart-icon">
      <i class="fas fa-shopping-cart"></i>
      <span class="cart-count">{{ cartItemCount }}</span>
    </a>
  </div>
</header>
```

### 2. Category Navigation
```html
<div class="categories">
  <div class="category" 
       *ngFor="let category of categories" 
       [class.active]="category === selectedCategory"
       (click)="selectCategory(category)">
    {{ category }}
  </div>
</div>
```

### 3. Filters Section
```html
<div class="filters">
  <div class="filter-group">
    <span class="filter-label">Sort By:</span>
    <select class="filter-select" [(ngModel)]="filters.sortBy" (change)="applyFilters()">
      <option value="bestselling">Best Selling</option>
      <option value="price_asc">Price: Low to High</option>
      <option value="price_desc">Price: High to Low</option>
      <option value="newest">Newest</option>
    </select>
  </div>
  
  <div class="filter-group price-range">
    <span class="filter-label">Price:</span>
    <input type="number" placeholder="Min" class="price-input" 
           [(ngModel)]="filters.minPrice">
    <span>-</span>
    <input type="number" placeholder="Max" class="price-input" 
           [(ngModel)]="filters.maxPrice">
    <button class="filter-button" (click)="applyFilters()">Filter</button>
  </div>
</div>
```

### 4. Product Card Component
```html
<div class="product-card">
  <div class="product-image" [style.background-image]="'url(' + product.imageUrl + ')'"></div>
  <div class="product-details">
    <h3 class="product-name">{{ product.name }}</h3>
    <div class="product-price">
      <span class="current-price">{{ product.price | currency:'VND':'symbol':'1.0-0' }}₫</span>
      <span class="original-price" *ngIf="product.originalPrice">{{ product.originalPrice | currency:'VND':'symbol':'1.0-0' }}₫</span>
      <span class="discount" *ngIf="product.discountPercentage">-{{ product.discountPercentage }}%</span>
    </div>
    <div class="product-actions">
      <button class="view-button" (click)="viewProduct(product.id)">View</button>
      <button class="add-button" (click)="addToCart(product)">Add to Cart</button>
    </div>
  </div>
</div>
```

### 5. Pagination Component
```html
<div class="pagination">
  <a href="#" class="page-link" (click)="$event.preventDefault(); previousPage()" [class.disabled]="currentPage === 1">«</a>
  <a href="#" class="page-link" *ngFor="let page of pages" 
     [class.active]="page === currentPage"
     (click)="$event.preventDefault(); goToPage(page)">
    {{ page }}
  </a>
  <a href="#" class="page-link" (click)="$event.preventDefault(); nextPage()" [class.disabled]="currentPage === totalPages">»</a>
</div>
```

### 6. Product Form Component (Admin)
```html
<div class="product-form-container">
  <h2>{{ isEditMode ? 'Edit Product' : 'Add New Product' }}</h2>
  
  <form [formGroup]="productForm" (ngSubmit)="onSubmit()">
    <div class="form-group">
      <label for="name">Product Name*</label>
      <input type="text" id="name" formControlName="name" class="form-control">
      <div class="error" *ngIf="submitted && f.name.errors">
        <span *ngIf="f.name.errors.required">Name is required</span>
      </div>
    </div>
    
    <div class="form-group">
      <label for="description">Description</label>
      <textarea id="description" formControlName="description" class="form-control"></textarea>
    </div>
    
    <div class="form-row">
      <div class="form-group">
        <label for="price">Current Price*</label>
        <input type="number" id="price" formControlName="price" class="form-control">
        <div class="error" *ngIf="submitted && f.price.errors">
          <span *ngIf="f.price.errors.required">Price is required</span>
        </div>
      </div>
      
      <div class="form-group">
        <label for="originalPrice">Original Price</label>
        <input type="number" id="originalPrice" formControlName="originalPrice" class="form-control">
      </div>
    </div>
    
    <!-- Additional form fields for category, image, tags, etc. -->
    
    <div class="form-actions">
      <button type="button" class="cancel-button" (click)="cancel()">Cancel</button>
      <button type="submit" class="submit-button">{{ isEditMode ? 'Update Product' : 'Add Product' }}</button>
    </div>
  </form>
</div>
```

### 7. Floating Action Button (Admin)
```html
<button class="add-product-button" *ngIf="isAdmin" (click)="navigateToAddProduct()">
  <i class="fas fa-plus"></i>
</button>
```
