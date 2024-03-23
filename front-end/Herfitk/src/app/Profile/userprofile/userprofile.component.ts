import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { UserService } from './user.service';
import { RouterModule } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { jwtDecode } from 'jwt-decode';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-userprofile',
  standalone: true,
  imports: [CommonModule, RouterModule,FormsModule],
  templateUrl: './userprofile.component.html',
  styleUrl: './userprofile.component.css',
  providers: [UserService, CookieService],
})
export class UserprofileComponent implements OnInit {
  userData: any;
  userId: any;

  constructor(
    private userService: UserService,
    private cookieService: CookieService
  ) {}

  ngOnInit(): void {
    this.getUserIdFromToken();
    this.fetchUserData();
  }

  getUserIdFromToken(): void {
    const token = this.cookieService.get('authToken');
    if (token) {
      const decodedToken: any = jwtDecode(token);
      this.userId =
        decodedToken[
          'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
        ];
      console.log(this.userId);
    }
  }

  fetchUserData(): void {
    // let id = this.userId
    this.userService.getUserData(this.userId).subscribe(
      (data: any) => {
        this.userData = data;
        console.log(this.userData);
      },
      (error: any) => {
        console.error('Failed to fetch user data:', error);
      }
    );
  }
}
