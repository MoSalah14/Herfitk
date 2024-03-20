import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Home/login/login.component';
import { RegisterComponent } from './Home/register/register.component';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { ViewprofileComponent } from './Profile/viewprofile/viewprofile.component';
import { DisplayHerfiysComponent } from './Display_Herfiys/display-herfiys/display-herfiys.component';
import { HomePageComponent } from './Home/home-page/home-page.component';
import { AboutComponent } from './Home/about/about.component';
import { CategoryComponent } from './Home/category/category.component';
import { ContactusComponent } from './Home/contactus/contactus.component';
import { PrivacypolicyComponent } from './Home/privacypolicy/privacypolicy.component';
import { TermsofservicesComponent } from './Home/termsofservices/termsofservices.component';

export const routes: Routes = [
  //  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: '', redirectTo: '/Home', pathMatch: 'full' },
  { path: 'Home', component: HomePageComponent },
  { path: 'app', component: AppComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'profile/:id', component: ViewprofileComponent },
  { path: 'privacy', component: PrivacypolicyComponent },
  { path: 'termofservices', component: TermsofservicesComponent },
  { path: 'display/:id', component: DisplayHerfiysComponent },
  { path: '**', redirectTo: '/Home' },
  // {path: "about" , component:AboutComponent},
  // {path: "category" , component:CategoryComponent},
  // {path: "contact" , component:ContactusComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
