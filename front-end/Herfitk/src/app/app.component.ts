import { Component, ViewChild, AfterViewInit, ElementRef } from '@angular/core';
import {
  Router,
  RouterLink,
  RouterModule,
  RouterOutlet,
} from '@angular/router';
import { LoginComponent } from './Account/login/login.component';
import { RegisterComponent } from './Account/register/register.component';
import { AboutComponent } from './Home/about/about.component';
import { ViewprofileComponent } from './Profile/viewprofile/viewprofile.component';
import { ContactusComponent } from './Home/contactus/contactus.component';
import { CategoryComponent } from './Home/category/category.component';
import { HeaderComponent } from './Home/header/header.component';
import { NavbarComponent } from './Home/navbar/navbar.component';
import { FooterComponent } from './Home/footer/footer.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { DisplayHerfiysComponent } from './Display_Herfiys/display-herfiys/display-herfiys.component';
import { HomePageComponent } from './Home/home-page/home-page.component';
import { DataSharingService } from './data-sharing.service';
import { RegsHerifyComponent } from './Account/regs-herify/regs-herify.component';
import { PrivacypolicyComponent } from './privacypolicy/privacypolicy.component';
import { TermsofservicesComponent } from './termsofservices/termsofservices.component';
import { UserprofileComponent } from './Profile/userprofile/userprofile.component';
import { PaymentComponent } from './payment/payment/payment.component';
import {
  TranslateModule,
  TranslateService,
  TranslateStore,
} from '@ngx-translate/core';
import { AppModuleModule } from './app-module.module';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { loaderInterceptor } from './Interceptors/loader.interceptor';

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
    // HttpClientModule,
    DisplayHerfiysComponent,
    HomePageComponent,
    PrivacypolicyComponent,
    TermsofservicesComponent,
    RegsHerifyComponent,
    UserprofileComponent,
    PaymentComponent,
    TranslateModule,
    AppModuleModule,
    NgxSpinnerModule,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [DataSharingService, TranslateService, TranslateStore],
})
export class AppComponent implements AfterViewInit {
  title = 'Herfitk';

  constructor(
    private elementRef: ElementRef,
    private translate: TranslateService
  ) {
    this.translate.setDefaultLang('en');
  }

  SwitchLanguage(language: string) {
    this.translate.use(language);
  }

  @ViewChild('translateElement') translateElement!: ElementRef;

  ngAfterViewInit(): void {
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor =
      '#17191a';
    // this.loadGoogleTranslateScript();
  }

  // private loadGoogleTranslateScript(): void {
  //   const script = document.createElement('script');
  //   script.type = 'text/javascript';
  //   script.text = `
  //     function googleTranslateElementInit() {
  //       new google.translate.TranslateElement({pageLanguage: 'en'}, 'google_translate_element');
  //     }
  //   `;
  //   this.translateElement.nativeElement.appendChild(script);
  // }
}
