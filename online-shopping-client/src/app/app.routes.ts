import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: "login",
    loadComponent: () =>
      import("./auth/login/login.component")
      .then((m) => m.LoginComponent),
      pathMatch: "full"
  },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: '**', redirectTo: '/login' } // Manejo de rutas no encontradas
];
