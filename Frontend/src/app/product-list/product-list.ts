import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ProductService } from '../services/product.service';
import { Product, ProductQueryParams } from '../models/product.model';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './product-list.html',
  styleUrl: './product-list.css'
})
export class ProductList implements OnInit {
  products: Product[] = [];
  loading = false;
  error: string | null = null;
  
  // Pagination
  currentPage = 1;
  pageSize = 9;
  totalPages = 0;
  totalCount = 0;
  
  // Filters
  selectedCategory = '';
  minPrice: number | null = null;
  maxPrice: number | null = null;
  showOnSale = false;
  showFeatured = false;
  sortBy = 'name';
  sortDesc = false;
  searchTerm = '';
  
  // Available categories (will be populated from API response)
  categories: string[] = [];

  constructor(private productService: ProductService, private router: Router) {}

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
    this.loading = true;
    this.error = null;
    
    const params: ProductQueryParams = {
      page: this.currentPage,
      pageSize: this.pageSize,
      sortBy: this.sortBy
    };
      if (this.selectedCategory) params.category = this.selectedCategory;
    if (this.minPrice !== null) params.minPrice = this.minPrice;
    if (this.maxPrice !== null) params.maxPrice = this.maxPrice;
    if (this.showOnSale) params.onSale = this.showOnSale;
    if (this.showFeatured) params.featured = this.showFeatured;
    params.sortDesc = this.sortDesc;    this.productService.getProducts(params).subscribe({
      next: (response) => {
        console.log(response);
        
        this.products = response.items;
        this.totalCount = response.totalItems;
        this.totalPages = response.totalPages;
        this.currentPage = response.pageNumber;
        
        // Extract unique categories
        const uniqueCategories = new Set<string>();
        this.products.forEach(p => {
          if (p.category) uniqueCategories.add(p.category);
        });
        this.categories = Array.from(uniqueCategories);
        
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Failed to load products. Please try again later.';
        this.loading = false;
        console.error('Error loading products:', err);
      }
    });
  }

  applyFilters() {
    this.currentPage = 1;
    this.loadProducts();
  }

  clearFilters() {
    this.selectedCategory = '';
    this.minPrice = null;
    this.maxPrice = null;
    this.showOnSale = false;
    this.showFeatured = false;
    this.sortBy = 'name';
    this.sortDesc = false;
    this.searchTerm = '';
    this.currentPage = 1;
    this.loadProducts();
  }

  changePage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
      this.loadProducts();
    }
  }

  changeSort(field: string) {
    if (this.sortBy === field) {
      this.sortDesc = !this.sortDesc;
    } else {
      this.sortBy = field;
      this.sortDesc = false;
    }
    this.currentPage = 1;
    this.loadProducts();
  }

  viewProduct(productId: number) {
    this.router.navigate(['/product', productId]);
  }

  onImageError(event: any) {
    event.target.src = '/assets/placeholder-product.jpg';
  }

  getPageNumbers(): number[] {
    const pages: number[] = [];
    const maxPages = 5;
    
    if (this.totalPages <= maxPages) {
      // If total pages is less than max, show all pages
      for (let i = 1; i <= this.totalPages; i++) {
        pages.push(i);
      }
    } else {
      // Always show first page
      pages.push(1);
      
      let startPage = Math.max(2, this.currentPage - 1);
      let endPage = Math.min(this.totalPages - 1, this.currentPage + 1);
      
      // Adjust if at the start
      if (this.currentPage <= 3) {
        endPage = Math.min(this.totalPages - 1, 4);
      }
      
      // Adjust if at the end
      if (this.currentPage >= this.totalPages - 2) {
        startPage = Math.max(2, this.totalPages - 3);
      }
      
      // Add ellipsis if needed after first page
      if (startPage > 2) {
        pages.push(-1); // Use -1 to indicate ellipsis
      }
      
      // Add middle pages
      for (let i = startPage; i <= endPage; i++) {
        pages.push(i);
      }
      
      // Add ellipsis if needed before last page
      if (endPage < this.totalPages - 1) {
        pages.push(-2); // Use -2 to indicate ellipsis
      }
      
      // Always show last page
      pages.push(this.totalPages);
    }
    
    return pages;
  }
}
