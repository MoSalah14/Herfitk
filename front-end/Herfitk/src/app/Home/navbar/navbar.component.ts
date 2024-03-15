import { CommonModule } from '@angular/common';
import { Component,HostListener } from '@angular/core';
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule,
  LoginComponent
  ],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  isLoginPopupOpen: boolean = false;

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
