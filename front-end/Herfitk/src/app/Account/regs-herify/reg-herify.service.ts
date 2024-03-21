import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/internal/operators/catchError';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RegHerifyService {
  BaseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  CreateHerify(formData: FormData): Observable<any> {
    return this.http.post(`${this.BaseUrl}Herify/Create`, formData).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMessage =
          'An error occurred during Login. Please try again later.';
        if (error.error.errors != null) {
          errorMessage = error.error.errors[0];
        }
        return throwError(errorMessage); // Throw the error as an Observable
      })
    );
  }

  FetchCategory(): Observable<any> {
    return this.http.get(`${this.BaseUrl}Category/Getall`);
  }

  FetchIDs(): Observable<any> {
    return this.http.get(`${this.BaseUrl}Herify/lastId`);
  }

  AddHerifyCategory(Obj: any): Observable<any> {
    return this.http.post(`${this.BaseUrl}HerifyCategories/create`, Obj);
  }
}
