using System.ComponentModel.DataAnnotations;

namespace Copilot.Models
{
    /// <summary>
    /// Represents a product in the e-commerce system.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Unique identifier for the product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the product.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Detailed description of the product.
        /// </summary>
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Original price of the product.
        /// </summary>
        [Required]
        [Range(0.01, 10000)]
        public decimal Price { get; set; }

        /// <summary>
        /// Discounted price of the product, if on sale.
        /// </summary>
        public decimal? DiscountPrice { get; set; }

        /// <summary>
        /// URL to the product image.
        /// </summary>
        [MaxLength(500)]
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Category to which the product belongs.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Brand of the product.
        /// </summary>
        [MaxLength(50)]
        public string Brand { get; set; } = string.Empty;

        /// <summary>
        /// Current stock quantity available for purchase.
        /// </summary>
        [Range(0, 10000)]
        public int StockQuantity { get; set; }

        /// <summary>
        /// Average customer rating (0-5).
        /// </summary>
        [Range(0, 5)]
        public decimal Rating { get; set; }

        /// <summary>
        /// Indicates whether the product is featured on the homepage.
        /// </summary>
        public bool IsFeatured { get; set; }

        /// <summary>
        /// Indicates whether the product is currently on sale.
        /// </summary>
        public bool IsOnSale { get; set; }

        /// <summary>
        /// Date when the product was added to the catalog.
        /// </summary>
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    }
}