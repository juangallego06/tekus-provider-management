import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import {
  CreateProviderRequest,
  Provider,
} from '../interfaces/provider.interface';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProvidersService {
  private http = inject(HttpClient);
  private readonly apiUrl = environment.apiUrl;

  getAll(): Observable<Provider[]> {
    return this.http.get<Provider[]>(`${this.apiUrl}/providers`);
  }

  create(payload: CreateProviderRequest): Observable<Provider> {
    return this.http.post<Provider>(`${this.apiUrl}/providers`, payload);
  }
}
