import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  private BaseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}
  // Observable : Handle Event and http Asynchronously
  CreateRegistration(formData: FormData) {
    return this.http.post(`${this.BaseUrl}Account/Register`, formData).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMessage = 'An error occurred during registration.';
        if (
          error.error &&
          error.error.errors &&
          error.error.errors.length > 0
        ) {
          errorMessage = error.error.errors;
        }
        return throwError(errorMessage);
      })
    );
  }

  CreateClient(user_id: any) {
    return this.http.post(`${this.BaseUrl}Clients/Add`, user_id).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMessage = 'An error occurred during registration.';
        if (
          error.error &&
          error.error.errors &&
          error.error.errors.length > 0
        ) {
          errorMessage = error.error.errors;
        }
        return throwError(errorMessage);
      })
    );
  }
}
