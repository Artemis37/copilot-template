using Microsoft.EntityFrameworkCore;
using Copilot.Models;

namespace Copilot.Data
{
    /// <summary>
    /// Database context for the Divine Shop application.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by the context.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the products in the database.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Configures the model and seeds initial data.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Divine Luxury Watch",
                    Description = "Elegant luxury watch with diamond embellishments and a gold-plated finish.",
                    Price = 599.99M,
                    DiscountPrice = 499.99M,
                    ImageUrl = "/images/luxury-watch.jpg",
                    Category = "Watches",
                    Brand = "Divine Luxury",
                    StockQuantity = 10,
                    Rating = 4.8M,
                    IsFeatured = true,
                    IsOnSale = true,
                    DateAdded = DateTime.UtcNow.AddDays(-30)
                },
                new Product
                {
                    Id = 2,
                    Name = "Divine Premium Headphones",
                    Description = "Noise-cancelling wireless headphones with premium sound quality and comfort.",
                    Price = 349.99M,
                    DiscountPrice = 299.99M,
                    ImageUrl = "/images/headphones.jpg",
                    Category = "Electronics",
                    Brand = "Divine Audio",
                    StockQuantity = 25,
                    Rating = 4.6M,
                    IsFeatured = true,
                    IsOnSale = true,
                    DateAdded = DateTime.UtcNow.AddDays(-15)
                },
                new Product
                {
                    Id = 3,
                    Name = "Divine Leather Handbag",
                    Description = "Handcrafted luxury leather handbag with gold accents.",
                    Price = 899.99M,
                    DiscountPrice = null,
                    ImageUrl = "/images/leather-handbag.jpg",
                    Category = "Fashion",
                    Brand = "Divine Fashion",
                    StockQuantity = 5,
                    Rating = 4.9M,
                    IsFeatured = true,
                    IsOnSale = false,
                    DateAdded = DateTime.UtcNow.AddDays(-7)
                },
                new Product
                {
                    Id = 4,
                    Name = "Divine Smart Watch",
                    Description = "Smart watch with health monitoring features and premium design.",
                    Price = 299.99M,
                    DiscountPrice = 249.99M,
                    ImageUrl = "/images/smart-watch.jpg",
                    Category = "Electronics",
                    Brand = "Divine Tech",
                    StockQuantity = 50,
                    Rating = 4.5M,
                    IsFeatured = false,
                    IsOnSale = true,
                    DateAdded = DateTime.UtcNow.AddDays(-10)
                },
                new Product
                {
                    Id = 5,
                    Name = "Divine Perfume",
                    Description = "Luxury fragrance with notes of jasmine, sandalwood, and vanilla.",
                    Price = 199.99M,
                    DiscountPrice = null,
                    ImageUrl = "/images/perfume.jpg",
                    Category = "Beauty",
                    Brand = "Divine Scents",
                    StockQuantity = 30,
                    Rating = 4.7M,
                    IsFeatured = false,
                    IsOnSale = false,
                    DateAdded = DateTime.UtcNow.AddDays(-20)
                },
                new Product
                {
                    Id = 6,
                    Name = "Divine Designer Sunglasses",
                    Description = "Polarized designer sunglasses with UV protection.",
                    Price = 249.99M,
                    DiscountPrice = 199.99M,
                    ImageUrl = "/images/sunglasses.jpg",
                    Category = "Fashion",
                    Brand = "Divine Eyewear",
                    StockQuantity = 15,
                    Rating = 4.4M,
                    IsFeatured = false,
                    IsOnSale = true,
                    DateAdded = DateTime.UtcNow.AddDays(-25)
                },
                new Product
                {
                    Id = 7,
                    Name = "Divine Smartphone",
                    Description = "Flagship smartphone with high-resolution camera and fast processor.",
                    Price = 999.99M,
                    DiscountPrice = 899.99M,
                    ImageUrl = "/images/smartphone.jpg",
                    Category = "Electronics",
                    Brand = "Divine Tech",
                    StockQuantity = 40,
                    Rating = 4.7M,
                    IsFeatured = true,
                    IsOnSale = true,
                    DateAdded = DateTime.UtcNow.AddDays(-5)
                },
                new Product
                {
                    Id = 8,
                    Name = "Divine Skincare Set",
                    Description = "Premium skincare set with anti-aging formula.",
                    Price = 149.99M,
                    DiscountPrice = null,
                    ImageUrl = "/images/skincare-set.jpg",
                    Category = "Beauty",
                    Brand = "Divine Skincare",
                    StockQuantity = 20,
                    Rating = 4.6M,
                    IsFeatured = false,
                    IsOnSale = false,
                    DateAdded = DateTime.UtcNow.AddDays(-12)
                }
            );
        }
    }
}