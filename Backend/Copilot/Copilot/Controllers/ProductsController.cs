using Copilot.Models;
using Copilot.Models.DTOs;
using Copilot.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Copilot.Controllers
{
    /// <summary>
    /// API controller for managing products.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Gets a paginated list of products with optional filtering and sorting.
        /// </summary>
        /// <param name="parameters">Query parameters for filtering, sorting, and pagination</param>
        /// <returns>A paginated list of products</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginatedResponse<Product>>> GetProducts([FromQuery] ProductQueryParameters parameters)
        {
            var products = await _productRepository.GetAllProductsAsync(
                parameters.Category,
                parameters.MinPrice,
                parameters.MaxPrice,
                parameters.SortBy,
                parameters.SortDesc,
                parameters.OnSale,
                parameters.Featured,
                parameters.Page,
                parameters.PageSize);

            var totalCount = await _productRepository.GetProductCountAsync(
                parameters.Category,
                parameters.MinPrice,
                parameters.MaxPrice,
                parameters.OnSale,
                parameters.Featured);

            var response = new PaginatedResponse<Product>
            {
                Items = products,
                TotalItems = totalCount,
                PageNumber = parameters.Page,
                PageSize = parameters.PageSize
            };

            return Ok(response);
        }

        /// <summary>
        /// Gets a specific product by ID.
        /// </summary>
        /// <param name="id">The ID of the product</param>
        /// <returns>The product with the specified ID</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">The product to create</param>
        /// <returns>The created product</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdProduct = await _productRepository.CreateProductAsync(product);

            return CreatedAtAction(
                nameof(GetProduct),
                new { id = createdProduct.Id },
                createdProduct);
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">The ID of the product to update</param>
        /// <param name="product">The updated product data</param>
        /// <returns>The updated product</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> UpdateProduct(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest("ID in URL must match ID in request body");
            }

            var updatedProduct = await _productRepository.UpdateProductAsync(id, product);

            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="id">The ID of the product to delete</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productRepository.DeleteProductAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Gets a list of all product categories.
        /// </summary>
        /// <returns>A list of unique categories</returns>
        [HttpGet("categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<string>>> GetCategories()
        {
            var categories = await _productRepository.GetCategoriesAsync();
            return Ok(categories);
        }
    }
}