import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { GoogleLoginProvider, SocialAuthServiceConfig, SocialLoginModule } from '@abacritt/angularx-social-login';
@Component({
  selector: 'app-register',
  standalone: true,
  imports: [RouterModule,
            FormsModule,
            CommonModule,
            ReactiveFormsModule,
            SocialLoginModule],
  templateUrl: './register.component.html',
  providers: [
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider('Google-Client-ID-Goes-Here'),
          },
        ],
      } as SocialAuthServiceConfig,
    },
  ],
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  name: any = '';
  email: any = '';
  phone: any = '';
  adress: any = '';
  naId: any = '';
  password: any = '';
  confirmPassword: any = '';
  submitted: boolean = false;
  showEmailRequiredMessage: boolean = false;
  constructor(private router:Router){}
  // constructor() { }

  FormValdiation = new FormGroup({
    name: new FormControl("",[Validators.maxLength(20)]),
    email: new FormControl("",[Validators.email]),
    phone: new FormControl("",[Validators.maxLength(11)]),
    adress: new FormControl("",[Validators.minLength(3) , Validators.maxLength(30)]),
    naId: new FormControl("",[Validators.minLength(14),Validators.maxLength(14)]),
    password: new FormControl("",[Validators.minLength(8)]),
    confirmPassword: new FormControl("",[Validators.minLength(8)])


  })
  get validname() {
    return this.FormValdiation.controls['name'].valid
  }
  get validEmail() {
    return this.FormValdiation.controls['email'].valid
  }
  get validPhone() {
    return this.FormValdiation.controls['phone'].valid
  }
  get validAdress() {
    return this.FormValdiation.controls['adress'].valid
  }
  get validnaId() {
    return this.FormValdiation.controls['naId'].valid
  }
  get validPass() {
    return this.FormValdiation.controls['password'].valid
  }
  get validConfirmPass() {
    return this.FormValdiation.controls['confirmPassword'].valid
  }

  logSuc(name:any , email:any , phone:any , adress:any , naId:any , password:any ,  confirmPassword:any){

    if (email == '' || password == '' || name == '') {
      this.showEmailRequiredMessage = true;
    }
    else if (phone == '' || adress == '' || naId == '') {
      this.showEmailRequiredMessage = true;
    }
   else if (confirmPassword == '') {
      this.showEmailRequiredMessage = true;
    }
    // else if (email.valid) {
    //   this.submitted = true;
    // }

    if(password !== confirmPassword) {
      alert("The Password Not Match With Confirm Password");
    }
    if(this.FormValdiation.valid) {
      alert( "Register suc")
      this.router.navigate(['app']);
    }
  }
}
