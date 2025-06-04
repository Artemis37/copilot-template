using Copilot.Models;

namespace Copilot.Repositories
{
    /// <summary>
    /// Interface for product repository operations.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Gets all products with optional filtering, sorting, and pagination.
        /// </summary>
        /// <param name="category">Filter by category</param>
        /// <param name="minPrice">Filter by minimum price</param>
        /// <param name="maxPrice">Filter by maximum price</param>
        /// <param name="sortBy">Field to sort by</param>
        /// <param name="sortDesc">Sort in descending order if true</param>
        /// <param name="onSale">Filter by sale status</param>
        /// <param name="featured">Filter by featured status</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Items per page</param>
        /// <returns>Collection of products</returns>
        Task<IEnumerable<Product>> GetAllProductsAsync(
            string? category = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            string? sortBy = null,
            bool sortDesc = false,
            bool? onSale = null,
            bool? featured = null,
            int page = 1,
            int pageSize = 10);
            
        /// <summary>
        /// Gets the total count of products matching the filter criteria.
        /// </summary>
        /// <param name="category">Filter by category</param>
        /// <param name="minPrice">Filter by minimum price</param>
        /// <param name="maxPrice">Filter by maximum price</param>
        /// <param name="onSale">Filter by sale status</param>
        /// <param name="featured">Filter by featured status</param>
        /// <returns>Total count of matching products</returns>
        Task<int> GetProductCountAsync(
            string? category = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            bool? onSale = null,
            bool? featured = null);
            
        /// <summary>
        /// Gets a product by ID.
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Product if found, otherwise null</returns>
        Task<Product?> GetProductByIdAsync(int id);
        
        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">Product to create</param>
        /// <returns>Created product</returns>
        Task<Product> CreateProductAsync(Product product);
        
        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">ID of product to update</param>
        /// <param name="product">Updated product data</param>
        /// <returns>Updated product if found, otherwise null</returns>
        Task<Product?> UpdateProductAsync(int id, Product product);
        
        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="id">ID of product to delete</param>
        /// <returns>True if deleted, false if not found</returns>
        Task<bool> DeleteProductAsync(int id);
        
        /// <summary>
        /// Gets all unique product categories.
        /// </summary>
        /// <returns>Collection of category names</returns>
        Task<IEnumerable<string>> GetCategoriesAsync();
    }
}