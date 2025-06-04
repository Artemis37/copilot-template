import { Routes } from '@angular/router';
import { Home } from './home/home';
import { ProductList } from './product-list/product-list';

export const routes: Routes = [
  { path: '', component: Home },
  { path: 'product', component: ProductList },
  { 
    path: 'product/:id', 
    loadComponent: () => import('./product-detail/product-detail').then(m => m.ProductDetail) 
  },
  { path: '**', redirectTo: '' }
];
