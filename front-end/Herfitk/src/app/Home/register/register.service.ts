import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  private BaseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}
  // Observable : Handle Event and http Asynchronously
  CreateRegistration(formData: FormData, userData: any): Observable<any> {
    return this.http.post<any>(`${this.BaseUrl}Account/Register`, {
      formData,
      userData,
    });
  }
}
