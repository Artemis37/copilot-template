# Product Management UI Instructions

This document provides instructions for implementing a product management UI. The UI should be implemented using Angular and will integrate with a backend API for full CRUD functionality.

## Overview

The product management UI should closely resemble the e-commerce interface shown in the reference image, featuring:

1. A responsive grid layout of product cards
2. Filtering and sorting options
3. Price range filters
4. Category navigation
5. Search functionality
6. Product management features (add, edit, delete)

## Implementation Details

- Component structure and organization
- Styling guidelines with specific color codes
- API integration details
- Data models and interfaces
- Responsive design specifications
- Sample code snippets for key components

## Required Features

At minimum, the implementation should include:

- **Product Listing**: Grid display of products with image, name, price, and discount information
- **Product Filtering**: By category, price range, and search term
- **Product Sorting**: By price (ascending/descending), newest, etc.
- **Pagination**: Navigation through multiple pages of products
- **Product Management**: Forms for adding and editing product details
- **Responsive Design**: UI adapts to desktop, tablet, and mobile viewports
- **Full API Integration**: All CRUD operations connect to the backend API

## API Configuration

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

## Getting Started

1. Install dependencies: `npm install`
2. Start the development server: `npm start`
3. Follow the component structure outlined in `PRODUCT-UI-INSTRUCTIONS.md`
4. Start building components from the ground up, beginning with data models and services

## Note
Keep the router-outlet from Angular and use router to display my product list component in the router outlet position