using System.ComponentModel.DataAnnotations;

namespace Copilot.Models.DTOs
{
    /// <summary>
    /// Query parameters for filtering, sorting, and paginating product results.
    /// </summary>
    public class ProductQueryParameters
    {
        /// <summary>
        /// Filter products by category.
        /// </summary>
        public string? Category { get; set; }
        
        /// <summary>
        /// Filter products by minimum price.
        /// </summary>
        [Range(0, 10000)]
        public decimal? MinPrice { get; set; }
        
        /// <summary>
        /// Filter products by maximum price.
        /// </summary>
        [Range(0, 10000)]
        public decimal? MaxPrice { get; set; }
        
        /// <summary>
        /// Filter products by sale status.
        /// </summary>
        public bool? OnSale { get; set; }
        
        /// <summary>
        /// Filter products by featured status.
        /// </summary>
        public bool? Featured { get; set; }
        
        /// <summary>
        /// Field to sort by (e.g., "price", "name", "rating").
        /// </summary>
        public string? SortBy { get; set; }
        
        /// <summary>
        /// Sort in descending order if true.
        /// </summary>
        public bool SortDesc { get; set; } = false;
        
        /// <summary>
        /// Page number, starting from 1.
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
        
        /// <summary>
        /// Number of items per page.
        /// </summary>
        [Range(1, 50)]
        public int PageSize { get; set; } = 10;
    }
}