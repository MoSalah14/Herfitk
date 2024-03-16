import { Component } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { CategoryComponent } from '../category/category.component';
import { AboutComponent } from '../about/about.component';
import { ContactusComponent } from '../contactus/contactus.component';
import { RouterLink, RouterModule } from '@angular/router';

@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [
    HeaderComponent,
    CategoryComponent,
    AboutComponent,
    ContactusComponent,
    RouterModule,
    RouterLink
  ],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css',
})
export class HomePageComponent {}
