# Product Management UI Instructions

This document provides instructions for implementing a product management UI based on the reference design shown in `src/assets/product-ui-reference.png`. The UI should be implemented using Angular and will integrate with a backend API for full CRUD functionality.

## Overview

The product management UI should closely resemble the e-commerce interface shown in the reference image, featuring:

1. A responsive grid layout of product cards
2. Filtering and sorting options
3. Price range filters
4. Category navigation
5. Search functionality
6. Product management features (add, edit, delete)

## Implementation Details

For detailed implementation instructions, refer to `PRODUCT-UI-INSTRUCTIONS.md` which includes:

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

- **GET /api/products** - Retrieve all products
- **GET /api/products/{id}** - Retrieve a specific product by ID
- **POST /api/products** - Create a new product
- **PUT /api/products/{id}** - Update an existing product
- **DELETE /api/products/{id}** - Delete a product

## Getting Started

1. Install dependencies: `npm install`
2. Start the development server: `npm start`
3. Follow the component structure outlined in `PRODUCT-UI-INSTRUCTIONS.md`
4. Start building components from the ground up, beginning with data models and services