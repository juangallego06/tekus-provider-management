import { HttpInterceptorFn, HttpErrorResponse } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { ErrorService } from '../services/error.service';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const errorService = inject(ErrorService);

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      let message = 'Error inesperado';

      switch (error.status) {
        case 400:
          message = error.error?.message || 'Solicitud inválida';
          break;
        case 401:
          message = 'No autorizado';
          break;
        case 403:
          message = 'Acceso denegado';
          break;
        case 404:
          message = 'Recurso no encontrado';
          break;
        case 500:
          message = 'Error interno del servidor';
          break;
        default:
          message = error.error?.message || 'Ocurrió un error';
          break;
      }

      errorService.show(message, error.status);
      return throwError(() => error);
    }),
  );
};
