import { Component, ViewChild } from '@angular/core';
import { RouterLink, RouterModule, RouterOutlet } from '@angular/router';
import { LoginComponent } from './Home/login/login.component';
import { RegisterComponent } from './Home/register/register.component';
import { AboutComponent } from './Home/about/about.component';
import { ViewprofileComponent } from './Profile/viewprofile/viewprofile.component';
import { DynamicBackgroundDirectiveDirective } from './Directives/dynamic-background-directive.directive';
import { ContactusComponent } from './Home/contactus/contactus.component';
import { CategoryComponent } from './Home/category/category.component';
import { HeaderComponent } from './Home/header/header.component';



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
  DynamicBackgroundDirectiveDirective

  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {
  title = 'Herfitk';


}
