import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Home/login/login.component';
import { RegisterComponent } from './Home/register/register.component';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';

export const routes: Routes = [
  // { path: '', redirectTo: 'app', pathMatch: 'full' },
  {path: "login" , component:LoginComponent},
  {path: "register" , component:RegisterComponent},
   {path: "app" , component:AppComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
