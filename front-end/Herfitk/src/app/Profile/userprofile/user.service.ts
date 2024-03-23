import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export interface UserProfile {
  // Define the properties of the UserProfile interface
  displayName: string;
  email: string;
  // Add more properties as needed
  // @Injectable({
  //   providedIn: 'root'
  // })
}
@Injectable({
  providedIn: 'root',
})
export class UserService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  // Method to fetch user data without specifying a specific type
  getUserData(userID: any): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}Account/${userID}`);
  }
}
