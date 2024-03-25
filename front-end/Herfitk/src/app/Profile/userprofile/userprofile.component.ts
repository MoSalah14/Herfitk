import { CommonModule } from '@angular/common';
import { Component, OnInit, Input } from '@angular/core';
import { UserService } from './user.service';
import { RouterModule } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { jwtDecode } from 'jwt-decode';
import { FormsModule } from '@angular/forms';
import { JWT_OPTIONS, JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-userprofile',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './userprofile.component.html',
  styleUrl: './userprofile.component.css',
  providers: [
    UserService,
    CookieService,
    JwtHelperService,
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
  ],
})
export class UserprofileComponent implements OnInit {
  userRole: string = ''; // Initialize with a default value
  userData: any;
  userId: any;
  showPayButton: boolean = false;

  constructor(
    private userService: UserService,
    private cookieService: CookieService,
    private jwtHelper: JwtHelperService
  ) {
    this.checkUserRole();
  }

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
  checkUserRole() {
    const authToken = this.cookieService.get('authToken');
    if (authToken) {
      const decodedToken = this.jwtHelper.decodeToken(authToken);
      console.log(decodedToken);
      this.userRole = decodedToken['UserRole'];
      console.log(this.userRole);
    }
    if (this.userRole === '4') {
      // Set showPayButton to true if the user role is '4'
      this.showPayButton = true;
    }
  }
  isEditing: boolean = false;
  //when click on edit button can type ih input label and show submit button

  toggleEdit() {
    this.isEditing = !this.isEditing;
  }

  updateUserData(event: any, propertyName: string): void {
    const propertyValue = event.target.value;
    this.userData[propertyName] = propertyValue;
  }

  submitData() {
    console.log('Data to be submitted:', this.userData); // Log the data before sending
    this.userService.UpdateUser(this.userId, this.userData).subscribe(
      (response: any) => {
        console.log('Update successful:', response);
        window.alert('Update successful');
      },
      (error: any) => {
        console.error('Update failed:', error);
        // Handle the error, such as showing an error message to the user
      }
    );
  }
}
