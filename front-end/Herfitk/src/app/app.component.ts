import { Component, ViewChild ,AfterViewInit,ElementRef} from '@angular/core';
import { Router, RouterLink, RouterModule, RouterOutlet } from '@angular/router';
import { LoginComponent } from './Home/login/login.component';
import { RegisterComponent } from './Home/register/register.component';
import { AboutComponent } from './Home/about/about.component';
import { ViewprofileComponent } from './Profile/viewprofile/viewprofile.component';
import { ContactusComponent } from './Home/contactus/contactus.component';
import { CategoryComponent } from './Home/category/category.component';
import { HeaderComponent } from './Home/header/header.component';
import { NavbarComponent } from './Home/navbar/navbar.component';
import { FooterComponent } from './Home/footer/footer.component';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
  HeaderComponent,
  LoginComponent,
  RegisterComponent,
  AboutComponent,
  RouterModule,
  RouterLink,
  RouterOutlet,
  CategoryComponent,
  ViewprofileComponent,
  ContactusComponent,
  NavbarComponent,
  FooterComponent

  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements AfterViewInit {
  constructor(private elementRef: ElementRef) {}
  ngAfterViewInit() {
      this.elementRef.nativeElement.ownerDocument
          .body.style.backgroundColor = '#17191a';
  }
  
  title = 'Herfitk';

 

}
