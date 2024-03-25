import { CommonModule } from '@angular/common';
import { Component, HostListener, OnInit } from '@angular/core';
import { LoginComponent } from '../../Account/login/login.component';
import { CookieService } from 'ngx-cookie-service';
import { JWT_OPTIONS, JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

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
  userId: any; // Example user ID

  constructor(
    private cookieService: CookieService,
    private jwtHelper: JwtHelperService, // Inject JwtHelperService
    private router: Router
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

      this.userId =
        decodedToken[
          'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
        ];
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

  goToDisplay() {
    this.router.navigate(['/user/' + this.userId]); // Navigate to '/user/:id' route
  }

  //Dark and Light Mode
  toggleBackground() {
    const switchInput = document.getElementById('switch') as HTMLInputElement;
    // const body = document.body;
    const headTirle = document.getElementById('headTirle') as HTMLInputElement;
    const body = document.body;

    //About
    const aboutbody = document.getElementById('aboutbody') as HTMLInputElement;
    const abouth1 = document.getElementById('abouth1') as HTMLInputElement;
    const abouth2 = document.getElementById('abouth2') as HTMLInputElement;
    const aboutp = document.getElementById('aboutp') as HTMLInputElement;
    //Category
    // const cardcat=document.getElementById('cardcat')  as HTMLInputElement;
    //footer
    const footer=document.getElementById('footer') as HTMLInputElement;
    const top=document.getElementById('top') as HTMLInputElement;
    const footbody=document.getElementById('footbody') as HTMLInputElement;
    const down=document.getElementById('down') as HTMLInputElement;
    const foot=document.getElementById('foot') as HTMLInputElement;
    const contact=document.getElementById('contact') as HTMLInputElement;
    const word1=document.getElementById('word1') as HTMLInputElement;
    const word2=document.getElementById('word2') as HTMLInputElement;
    const word3=document.getElementById('word3') as HTMLInputElement;
    const herf=document.getElementById('herf') as HTMLInputElement;
    const aboutherf=document.getElementById('aboutherf') as HTMLInputElement;
    const newh=document.getElementById('newh') as HTMLInputElement;
    const sub=document.getElementById('sub') as HTMLInputElement;
    const cop=document.getElementById('cop') as HTMLInputElement;
    const linkfoot=document.getElementById('linkfoot') as HTMLInputElement;
    //terms
    const term=document.getElementById('term') as HTMLInputElement;
    const th2 =document.getElementById('th2') as HTMLInputElement;
    //privacy
    const privacybody=document.getElementById('privacybody') as HTMLInputElement;
    //pay
    const pay=document.getElementById('pay') as HTMLInputElement;
    // const li = document.getElementsByTagName("li") as HTMLCollectionOf<HTMLLIElement>;
    //const contact = document.getElementsByClassName("contact") as HTMLCollectionOf<HTMLLIElement>;
    // const overlay = document.querySelectorAll('.overlay') as NodeListOf<HTMLElement>;

    if (switchInput.checked) {
      headTirle.style.color = 'black';
      body.style.backgroundColor='#d1d1d1';
      //About
      aboutbody.style.backgroundColor='#d1d1d1';
      abouth1.style.color='Black';
      abouth2.style.color='Black';
      aboutp.style.color='Black';
      //Category
      // cardcat.style.backgroundColor='black';
      //footer
      footer.style.backgroundColor='#d1d1d1';
     top.style.backgroundColor='#d1d1d1';
     footbody.style.backgroundColor='#d1d1d1';
     down.style.backgroundColor='#d1d1d1';
     down.style.color='Black';  
     foot.style.backgroundColor='#d1d1d1';
     contact.style.backgroundColor='#d1d1d1';
     word1.style.color='Black';
     word2.style.color='Black';
     word3.style.color='Black';
     herf.style.color='Black';
     aboutherf.style.color='Black';
     newh.style.color='Black';
     sub.style.color='Black';
     cop.style.color='Black';
     linkfoot.style.color='Black';
      //terms
      term.style.backgroundColor='#d1d1d1';
      term.style.color='Black';
      th2.style.color='Black';
      //privacy
      privacybody.style.backgroundColor='#d1d1d1';
      privacybody.style.color='Black';
      //payment
      pay.style.backgroundColor='#d1d1d1';
      pay.style.color='Black';



    } else {
      headTirle.style.color = 'white';
      body.style.backgroundColor='#17191a';
      //About
      aboutbody.style.backgroundColor="#17191a";
      abouth1.style.color='white';
      abouth2.style.color='white';
      aboutp.style.color='white';

      // cardcat.style.backgroundColor='black';
      footer.style.backgroundColor='#17191a';
      top.style.backgroundColor='#17191a';
      footbody.style.backgroundColor='#17191a';
      down.style.backgroundColor='#17191a';
      down.style.color='white';
      foot.style.backgroundColor='#d1d1d1';
      contact.style.backgroundColor='#17191a';
      word1.style.color='white';
      word2.style.color='white';
      word3.style.color='white';
      herf.style.color='white';
      aboutherf.style.color='white';
      newh.style.color='white';
      sub.style.color='white';
      cop.style.color='white';
      linkfoot.style.color='white';
      //term
      term.style.backgroundColor='#17191a';
      term.style.color='white';
      th2.style.color='white';
      //privacy
      privacybody.style.backgroundColor='#17191a';
      privacybody.style.color='white';
      //payment
      pay.style.backgroundColor='#17191a';
      pay.style.color='white';
    }
  }
}
// const listItems = document.querySelectorAll('single-footer-widget ul li'); 

// listItems.forEach(listItem => {
//   const anchor = listItem.querySelector('a')
//   if (anchor) {
//     anchor.style.backgroundColor = 'blue';
 
//   }
// });