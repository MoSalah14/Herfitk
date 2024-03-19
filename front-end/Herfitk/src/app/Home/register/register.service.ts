import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  private BaseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}
  // Observable : Handle Event and http Asynchronously
  CreateRegistration(formData: FormData) {
    return this.http.post(`${this.BaseUrl}Account/Register`, formData);
  }
}
