import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Home/login/login.component';
import { RegisterComponent } from './Home/register/register.component';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { ViewprofileComponent } from './Profile/viewprofile/viewprofile.component';
import { DisplayHerfiysComponent } from './Display_Herfiys/display-herfiys/display-herfiys.component';
import { HomePageComponent } from './Home/home-page/home-page.component';
import { AboutComponent } from './Home/about/about.component';

export const routes: Routes = [
//  { path: '', redirectTo: 'login', pathMatch: 'full' },
  {path: "app" , component:AppComponent},
  {path: "login" , component:LoginComponent},
  {path: "register" , component:RegisterComponent},
  {path: "profile" , component:ViewprofileComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
