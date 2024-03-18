import { Component, ViewChild, AfterViewInit, ElementRef } from '@angular/core';
import {
  Router,
  RouterLink,
  RouterModule,
  RouterOutlet,
} from '@angular/router';
import { LoginComponent } from './Home/login/login.component';
import { RegisterComponent } from './Home/register/register.component';
import { AboutComponent } from './Home/about/about.component';
import { ViewprofileComponent } from './Profile/viewprofile/viewprofile.component';
import { ContactusComponent } from './Home/contactus/contactus.component';
import { CategoryComponent } from './Home/category/category.component';
import { HeaderComponent } from './Home/header/header.component';
import { NavbarComponent } from './Home/navbar/navbar.component';
import { FooterComponent } from './Home/footer/footer.component';
import { HttpClientModule } from '@angular/common/http';
import { DisplayHerfiysComponent } from './Display_Herfiys/display-herfiys/display-herfiys.component';
import { HomePageComponent } from './Home/home-page/home-page.component';
import { PrivacypolicyComponent } from './Home/privacypolicy/privacypolicy.component';
import { TermsofservicesComponent } from './Home/termsofservices/termsofservices.component';

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
    FooterComponent,
    HttpClientModule,
    DisplayHerfiysComponent,
    HomePageComponent,
    PrivacypolicyComponent,
    TermsofservicesComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements AfterViewInit {
  title = 'Herfitk';

  constructor(private elementRef: ElementRef) {}

  @ViewChild('translateElement') translateElement!: ElementRef;

  ngAfterViewInit(): void {
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor =
      '#17191a';
    this.loadGoogleTranslateScript();
  }

  private loadGoogleTranslateScript(): void {
    const script = document.createElement('script');
    script.type = 'text/javascript';
    script.text = `
      function googleTranslateElementInit() {
        new google.translate.TranslateElement({pageLanguage: 'en'}, 'google_translate_element');
      }
    `;
    this.translateElement.nativeElement.appendChild(script);
  }
}
