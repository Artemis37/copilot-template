import { Routes } from '@angular/router';
import { Home } from './home/home';
import { ProductList } from './product-list/product-list';

export const routes: Routes = [
  { path: '', component: Home },
  { path: 'product', component: ProductList },
  { path: '**', redirectTo: '' }
];
