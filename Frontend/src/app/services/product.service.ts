import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product, ProductsResponse, ProductQueryParams } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = 'https://localhost:7194/api/products';

  constructor(private http: HttpClient) { }

  getProducts(params?: ProductQueryParams): Observable<ProductsResponse> {
    let httpParams = new HttpParams();

    if (params) {
      if (params.category) httpParams = httpParams.set('Category', params.category);
      if (params.minPrice !== undefined) httpParams = httpParams.set('MinPrice', params.minPrice.toString());
      if (params.maxPrice !== undefined) httpParams = httpParams.set('MaxPrice', params.maxPrice.toString());
      if (params.onSale !== undefined) httpParams = httpParams.set('OnSale', params.onSale.toString());
      if (params.featured !== undefined) httpParams = httpParams.set('Featured', params.featured.toString());
      if (params.sortBy) httpParams = httpParams.set('SortBy', params.sortBy);
      if (params.sortDesc !== undefined) httpParams = httpParams.set('SortDesc', params.sortDesc.toString());
      if (params.page) httpParams = httpParams.set('PageNumber', params.page.toString());
      if (params.pageSize) httpParams = httpParams.set('PageSize', params.pageSize.toString());
    }

    return this.http.get<ProductsResponse>(this.apiUrl, { params: httpParams });
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.apiUrl}/${id}`);
  }

  createProduct(product: Omit<Product, 'id'>): Observable<Product> {
    return this.http.post<Product>(this.apiUrl, product);
  }

  updateProduct(id: number, product: Product): Observable<Product> {
    return this.http.put<Product>(`${this.apiUrl}/${id}`, product);
  }

  deleteProduct(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
