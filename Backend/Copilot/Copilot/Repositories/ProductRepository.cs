using Copilot.Data;
using Copilot.Models;
using Microsoft.EntityFrameworkCore;

namespace Copilot.Repositories
{
    /// <summary>
    /// Repository for product operations.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Product>> GetAllProductsAsync(
            string? category = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            string? sortBy = null,
            bool sortDesc = false,
            bool? onSale = null,
            bool? featured = null,
            int page = 1,
            int pageSize = 10)
        {
            var query = _context.Products.AsQueryable();

            // Apply filters
            query = ApplyFilters(query, category, minPrice, maxPrice, onSale, featured);

            // Apply sorting
            query = ApplySorting(query, sortBy, sortDesc);

            // Apply pagination
            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<int> GetProductCountAsync(
            string? category = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            bool? onSale = null,
            bool? featured = null)
        {
            var query = _context.Products.AsQueryable();

            // Apply filters
            query = ApplyFilters(query, category, minPrice, maxPrice, onSale, featured);

            return await query.CountAsync();
        }

        /// <inheritdoc/>
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        /// <inheritdoc/>
        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        /// <inheritdoc/>
        public async Task<Product?> UpdateProductAsync(int id, Product product)
        {
            var existingProduct = await _context.Products.FindAsync(id);

            if (existingProduct == null)
            {
                return null;
            }

            // Update properties
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.DiscountPrice = product.DiscountPrice;
            existingProduct.ImageUrl = product.ImageUrl;
            existingProduct.Category = product.Category;
            existingProduct.Brand = product.Brand;
            existingProduct.StockQuantity = product.StockQuantity;
            existingProduct.Rating = product.Rating;
            existingProduct.IsFeatured = product.IsFeatured;
            existingProduct.IsOnSale = product.IsOnSale;

            await _context.SaveChangesAsync();
            return existingProduct;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            
            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<string>> GetCategoriesAsync()
        {
            return await _context.Products
                .Select(p => p.Category)
                .Distinct()
                .ToListAsync();
        }

        private IQueryable<Product> ApplyFilters(
            IQueryable<Product> query,
            string? category,
            decimal? minPrice,
            decimal? maxPrice,
            bool? onSale,
            bool? featured)
        {
            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(p => p.Category == category);
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.DiscountPrice.HasValue ? 
                    p.DiscountPrice.Value >= minPrice.Value : 
                    p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.DiscountPrice.HasValue ? 
                    p.DiscountPrice.Value <= maxPrice.Value : 
                    p.Price <= maxPrice.Value);
            }

            if (onSale.HasValue)
            {
                query = query.Where(p => p.IsOnSale == onSale.Value);
            }

            if (featured.HasValue)
            {
                query = query.Where(p => p.IsFeatured == featured.Value);
            }

            return query;
        }

        private IQueryable<Product> ApplySorting(
            IQueryable<Product> query, 
            string? sortBy, 
            bool sortDesc)
        {
            switch (sortBy?.ToLower())
            {
                case "price":
                    return sortDesc
                        ? query.OrderByDescending(p => p.DiscountPrice ?? p.Price)
                        : query.OrderBy(p => p.DiscountPrice ?? p.Price);
                case "name":
                    return sortDesc
                        ? query.OrderByDescending(p => p.Name)
                        : query.OrderBy(p => p.Name);
                case "rating":
                    return sortDesc
                        ? query.OrderByDescending(p => p.Rating)
                        : query.OrderBy(p => p.Rating);
                case "date":
                    return sortDesc
                        ? query.OrderByDescending(p => p.DateAdded)
                        : query.OrderBy(p => p.DateAdded);
                default:
                    // Default sort by ID
                    return sortDesc
                        ? query.OrderByDescending(p => p.Id)
                        : query.OrderBy(p => p.Id);
            }
        }
    }
}