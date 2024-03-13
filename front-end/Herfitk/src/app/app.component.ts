import { Component, ViewChild } from '@angular/core';
import { RouterLink, RouterModule, RouterOutlet } from '@angular/router';
import { HeaderComponent } from './Home/header/header.component';
import { LoginComponent } from './Home/login/login.component';
import { RegisterComponent } from './Home/register/register.component';
import { AboutComponent } from './Home/about/about.component';

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
  RouterOutlet
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {
  title = 'Herfitk';


}
