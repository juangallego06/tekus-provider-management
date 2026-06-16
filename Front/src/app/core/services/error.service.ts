import { Injectable, signal } from '@angular/core';
import { AlertError } from '../../shared/interfaces/alerts.interface';

@Injectable({ providedIn: 'root' })
export class ErrorService {
  private _error = signal<AlertError | null>(null);
  error = this._error.asReadonly();

  show(message: string, status?: number) {
    this._error.set({ message, status });
  }

  clear() {
    this._error.set(null);
  }
}
