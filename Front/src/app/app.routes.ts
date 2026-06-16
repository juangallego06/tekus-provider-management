import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  {
    path: 'login',
    loadComponent: () =>
      import('./features/auth/pages/login-page/login-page.component').then(
        (m) => m.LoginPageComponent,
      ),
  },

  {
    path: '',
    canActivate: [authGuard],

    loadComponent: () =>
      import('./shared/layouts/main-layout/main-layout.component').then(
        (m) => m.MainLayoutComponent,
      ),

    children: [
      {
        path: 'dashboard',
        loadComponent: () =>
          import('./features/dashboard/pages/dashboard-page/dashboard-page.component').then(
            (m) => m.DashboardPageComponent,
          ),
      },

      {
        path: 'providers',
        loadComponent: () =>
          import('./features/providers/pages/providers-page/providers-page.component').then(
            (m) => m.ProvidersPageComponent,
          ),
      },

      {
        path: 'services',
        loadComponent: () =>
          import('./features/services/pages/services-page/services-page.component').then(
            (m) => m.ServicesPageComponent,
          ),
      },
    ],
  },

  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'dashboard',
  },

  {
    path: '**',
    redirectTo: 'dashboard',
  },
];
