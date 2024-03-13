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
  constructor(private router:Router){}
  // constructor() { }

  onSubmit() {
    this.submitted = true;

    if (!this.name.trim()) {
      alert('Name is required');
      return;
    }
    if (!this.email.trim()) {
      alert('Email is required');
      return;
    }
    // if (!this.naId.trim()) {
    //   alert('National Id is required');
    //   return;
    // }
    if (!this.phone.trim()) {
      alert('Phone number is required');
      return;
    }

    if (this.password !== this.confirmPassword) {
      alert('Passwords do not match');
      return;
    }



  }

  FormValdiation = new FormGroup({
    name: new FormControl("",[Validators.maxLength(10)]),
    email: new FormControl("",[Validators.email]),
    phone: new FormControl("",[Validators.maxLength(11)]),
    adress: new FormControl("",[Validators.maxLength(30)]),
    // naId: new FormControl(null ,[Validators.maxLength(14)]),
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
  // get validnaId() {
  //   return this.FormValdiation.controls['naTd'].valid
  // }
  get validPass() {
    return this.FormValdiation.controls['password'].valid
  }
  get validConfirmPass() {
    return this.FormValdiation.controls['confirmPassword'].valid
  }

  logSuc(){
    if(this.FormValdiation.valid) {
      alert( "Register suc")
      this.router.navigate(['/header']);
    }
  }
}
