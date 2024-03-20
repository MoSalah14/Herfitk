import { CommonModule } from '@angular/common';
import { Component, HostListener, OnInit } from '@angular/core';
import { LoginComponent } from '../login/login.component';
import { CookieService } from 'ngx-cookie-service';
import { JWT_OPTIONS, JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, LoginComponent],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
  providers: [
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
    JwtHelperService,
    CookieService,
  ],
})
export class NavbarComponent implements OnInit {
  isLoginPopupOpen: boolean = false;
  userEmail: string | undefined;
  UserName: string | undefined;
  UserRole: string | undefined;
  isLoggedIn: boolean = false;

  constructor(
    private cookieService: CookieService,
    private jwtHelper: JwtHelperService // Inject JwtHelperService
  ) {}
  ngOnInit(): void {
    this.checkAuthStatus();
  }

  checkAuthStatus(): void {
    const authToken = this.cookieService.get('authToken');
    if (authToken) {
      const decodedToken = this.jwtHelper.decodeToken(authToken);
      this.userEmail =
        decodedToken[
          'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'
        ];
      this.UserName =
        decodedToken[
          'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'
        ];
      this.UserRole =
        decodedToken[
          'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
        ];
      this.isLoggedIn = true;
    }
  }

  logout(): void {
    this.isLoggedIn = false;
    this.cookieService.delete('authToken');
  }

  openLoginForm(): void {
    this.isLoginPopupOpen = true;
  }

  closeLoginForm(): void {
    this.isLoginPopupOpen = false;
  }

  isSticky: boolean = false;

  @HostListener('window:scroll', [])
  onWindowScroll() {
    const scrollY = window.scrollY || window.pageYOffset;
    this.isSticky = scrollY > 0;
  }
}
