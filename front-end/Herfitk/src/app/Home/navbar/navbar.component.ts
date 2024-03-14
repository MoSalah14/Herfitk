import { CommonModule } from '@angular/common';
import { Component,HostListener } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, CommonModule, RouterLinkActive],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  //  //Go To Login Page

  //  constructor(public router:Router){}


  // loginForm() {
  //   this.router.navigate(['login']);
  // }

  isSticky: boolean = false;

  @HostListener('window:scroll', [])
  onWindowScroll() {
    const scrollY = window.scrollY || window.pageYOffset;
    this.isSticky = scrollY > 0;
  }

}
