import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  private BaseUrl = environment.apiUrl;
  constructor(private client: HttpClient) {}

  makeLoginWithToken(email: string, password: string) {
    const loginData = { email, password }; // Create a JSON object with login data

    return this.client.post(`${this.BaseUrl}Account/login`, loginData).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMessage =
          'An error occurred during Login. Please try again later.';
        if (
          error.error &&
          error.error.errors &&
          error.error.errors.length > 0
        ) {
          errorMessage = error.error.errors[0];
        }
        return throwError(errorMessage); // Use throwError to propagate the error
      })
    );
  }
}
