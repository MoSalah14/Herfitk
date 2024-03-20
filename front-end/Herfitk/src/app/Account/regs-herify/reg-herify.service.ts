import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/internal/operators/catchError';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RegHerifyService {
  BaseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  CreateHerify(formData: FormData) {
    return this.http.post(`${this.BaseUrl}Herify/Create`, formData).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMessage = 'An error occurred';
        if (error.error instanceof ErrorEvent) {
          // Client-side error
          errorMessage = `Client-side error: ${error.error.message}`;
        } else {
          // Server-side error
          errorMessage = `Server-side error: ${error.status} - ${error.error}`;
        }
        console.error(errorMessage);
        return errorMessage;
      })
    );
  }
}
