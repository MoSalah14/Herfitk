import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './Home/header/header.component';
import { LoginComponent } from './Home/login/login.component';
import { RegisterComponent } from './Home/register/register.component';
import { AboutComponent } from './Home/about/about.component';
import { CategoryComponent } from './Home/category/category.component';
import { ViewprofileComponent } from './Profile/viewprofile/viewprofile.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,
  HeaderComponent,
  LoginComponent,
  RegisterComponent,
  AboutComponent,
  CategoryComponent,
  ViewprofileComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Herfitk';
}
