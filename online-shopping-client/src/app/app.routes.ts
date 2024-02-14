import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: "login",
    loadComponent: () =>
      import("./auth/login/login.component")
      .then((m) => m.LoginComponent),
      pathMatch: "full"
  },
  {
    path: "register",
    loadComponent: () =>
      import("./auth/register/register.component")
      .then((m) => m.RegisterComponent),
  },
  {
    path: "products",
    loadComponent: () =>
      import("./products/product-list/product-list.component")
      .then((m) => m.ProductListComponent),
  },
  {
    path: "cart",
    loadComponent: () =>
      import("./cart/cart-list/cart-list.component")
      .then((m) => m.CartListComponent),
  },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: '**', redirectTo: '/login' } // Manejo de rutas no encontradas
];
