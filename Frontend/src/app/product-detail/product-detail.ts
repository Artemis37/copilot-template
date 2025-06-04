import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product-detail',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './product-detail.html',
  styleUrl: './product-detail.css'
})
export class ProductDetail implements OnInit {
  product: Product | null = null;
  loading = true;
  error: string | null = null;
  
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService
  ) {}

  ngOnInit() {
    // Get the product ID from the route parameter
    this.route.paramMap.subscribe(params => {
      const productId = params.get('id');
      if (productId) {
        this.loadProduct(+productId);
      } else {
        this.error = "Product ID not found";
        this.loading = false;
      }
    });
  }

  loadProduct(id: number) {
    this.loading = true;
    this.error = null;

    this.productService.getProduct(id).subscribe({
      next: (product) => {
        this.product = product;
        this.loading = false;
      },
      error: (err) => {
        this.error = "Failed to load product details. The product may not exist.";
        this.loading = false;
        console.error('Error loading product details:', err);
      }
    });
  }

  goBack() {
    this.router.navigate(['/product']);
  }

  onImageError(event: any) {
    event.target.src = '/assets/placeholder-product.jpg';
  }
}
