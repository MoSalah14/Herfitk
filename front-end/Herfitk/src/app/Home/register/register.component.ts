import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import {
  GoogleLoginProvider,
  SocialAuthServiceConfig,
  SocialLoginModule,
} from '@abacritt/angularx-social-login';
@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    RouterModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    SocialLoginModule,
  ],
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
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  registrationForm: FormGroup;
  submitted = false;
  showEmailRequiredMessage = false;

  constructor(private router: Router, private fb: FormBuilder) {
    this.registrationForm = this.fb.group({
      name: [
        '',
        [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(20),
        ],
      ],
      email: ['', [Validators.required, Validators.email]],
      phone: [
        '',
        [Validators.required, Validators.pattern(/^(010|011|012|015)\d{8}$/)],
      ],
      address: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(30),
        ],
      ],
      naId: [
        '',
        [
          Validators.required,
          Validators.minLength(14),
          Validators.maxLength(14),
        ],
      ],
      password: ['', [Validators.required, Validators.minLength(8)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(8)]],
      personalPhoto: [null, [Validators.required]],
    });
  }
  onSubmit() {
    
    this.submitted = true;
    if (this.registrationForm.invalid) {
      return;
    }
    const formData = new FormData();
    formData.append('name', this.registrationForm.value.name);
    formData.append('email', this.registrationForm.value.email);
    formData.append('phone', this.registrationForm.value.phone);
    formData.append('address', this.registrationForm.value.address);
    formData.append('naId', this.registrationForm.value.naId);
    formData.append('password', this.registrationForm.value.password);
    formData.append(
      'confirmPassword',
      this.registrationForm.value.confirmPassword
    );
    formData.append('personalPhoto', this.registrationForm.value.personalPhoto);

    console.log(formData);

    alert('Registration successful!');
    this.router.navigate(['/login']); // Redirect to login page after successful registration
  }

  onFileChange(event: Event) {
    const target = event.target as HTMLInputElement;
    if (target.files && target.files.length) {
      const file = target.files[0];
      this.registrationForm.patchValue({
        personalPhoto: file,
      });
      this.registrationForm.get('personalPhoto')?.updateValueAndValidity();
    }
  }
  get formControls() {
    return this.registrationForm.controls;
  }
}
