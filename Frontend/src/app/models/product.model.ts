export interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  discountPrice?: number | null;
  imageUrl?: string;
  category: string;
  brand: string;
  stockQuantity: number;
  rating: number;
  isFeatured: boolean;
  isOnSale: boolean;
  dateAdded: string;
}

export interface ProductsResponse {
  items: Product[];
  totalItems: number;
  pageNumber: number;
  pageSize: number;
  totalPages: number;
  hasPreviousPage: boolean;
  hasNextPage: boolean;
}

export interface ProductQueryParams {
  category?: string;
  minPrice?: number;
  maxPrice?: number;
  onSale?: boolean;
  featured?: boolean;
  sortBy?: string;
  sortDesc?: boolean;
  page?: number;
  pageSize?: number;
}
