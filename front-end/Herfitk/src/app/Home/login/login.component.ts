import { Component, Output, EventEmitter } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { LoginService } from './login.service';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from '../register/register.component';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [
    RegisterComponent,
    RouterModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
  ],
  providers: [LoginService, CookieService],
})
export class LoginComponent {
  @Output() close: EventEmitter<void> = new EventEmitter<void>();

  // Declare the submitted property
  submitted: boolean = false;
  showEmailRequiredMessage: boolean = false;

  constructor(
    private router: Router,
    private loginService: LoginService,
    private fb: FormBuilder,
    private cookieService: CookieService
  ) {
    this.FormValidation = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  FormValidation = new FormGroup({
    email: new FormControl('', [Validators.email, Validators.required]),
    password: new FormControl('', [
      Validators.minLength(8),
      Validators.maxLength(12),
      Validators.required,
    ]),
  });

  get validEmail() {
    return this.FormValidation.controls['email'].valid;
  }
  get validPass() {
    return this.FormValidation.controls['password'].valid;
  }

  logSuc() {
    const emailControl = this.FormValidation.get('email');
    const passwordControl = this.FormValidation.get('password');

    // Check if email and password controls are defined and have non-null values
    if (
      emailControl &&
      emailControl.value !== null &&
      passwordControl &&
      passwordControl.value !== null
    ) {
      const email: string = emailControl.value as string;
      const password: string = passwordControl.value as string;

      this.loginService.makeLoginWithToken(email, password).subscribe({
        next: (response: any) => {
          console.log(response);

          this.cookieService.set('authToken', response.token);

          this.router.navigate(['app']); // Navigate to the desired route on success
        },
        error: (error) => {
          // Handle login error
          console.error('Login error:', error);
          // You can display an error message to the user or handle it in any way you prefer
          alert('Login failed. Please try again.'); // Example alert for login failure
        },
      });
    }

    // Set submitted to true after attempting login
    this.submitted = true;
  }

  closeLoginForm(): void {
    this.close.emit();
  }
}
