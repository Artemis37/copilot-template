# Product Management UI Implementation Guide

This Angular project implements a product management UI that integrates with a backend API for full CRUD functionality.

## Files and Documentation

1. **INSTRUCTIONS.md**: High-level overview of the implementation requirements
2. **PRODUCT-UI-INSTRUCTIONS.md**: Detailed implementation guide with component specifications, styling guidelines, and best practices
3. **product-ui-mockup.html**: HTML/CSS mockup of the product management UI
4. **src/assets/product-ui-reference.png**: Reference image for the UI design

## Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## API Integration

This project integrates with a backend API available at `https://localhost:7194` with the following endpoints:

- **GET /api/products** - Retrieve all products
- **GET /api/products/{id}** - Retrieve a specific product by ID
- **POST /api/products** - Create a new product
- **PUT /api/products/{id}** - Update an existing product
- **DELETE /api/products/{id}** - Delete a product

## Implementation Workflow

1. Start by reviewing the INSTRUCTIONS.md and PRODUCT-UI-INSTRUCTIONS.md files
2. Examine the product-ui-mockup.html and reference image to understand the UI layout and design
3. Follow the implementation steps in PRODUCT-UI-INSTRUCTIONS.md to create components, services, and models
4. Use the provided API endpoints to integrate with the backend
5. Implement responsive design according to the specifications

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

## Building

To build the project run:

```bash
ng build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Running unit tests

To execute unit tests with the [Karma](https://karma-runner.github.io) test runner, use the following command:

```bash
ng test
```

## Running end-to-end tests

For end-to-end (e2e) testing, run:

```bash
ng e2e
```

Angular CLI does not come with an end-to-end testing framework by default. You can choose one that suits your needs.

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.
