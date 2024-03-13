import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Home/login/login.component';
import { RegisterComponent } from './Home/register/register.component';
import { NgModule } from '@angular/core';
import { HeaderComponent } from './Home/header/header.component';

export const routes: Routes = [
  // { path: '', redirectTo: '/header', pathMatch: 'full' },
  {path: "login" , component:LoginComponent},
  {path: "register" , component:RegisterComponent},
  {path: "header" , component:HeaderComponent},



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
