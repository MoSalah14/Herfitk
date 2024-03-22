import { Component, ElementRef, ViewChild } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterService } from './register.service';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AutofocusDirective } from './autofocus.directive';
import { CookieService } from 'ngx-cookie-service';
import { jwtDecode } from 'jwt-decode';
import { EMPTY, concatMap } from 'rxjs';

const passwordMatchValidator = (control: FormGroup) => {
  const password = control.get('Password');
  const confirmPassword = control.get('confirmPassword');

  return password && confirmPassword && password.value !== confirmPassword.value
    ? { passwordMismatch: true }
    : null;
};

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, FormsModule, AutofocusDirective],
  providers: [RegisterService],
})
export class RegisterComponent {
  @ViewChild('firstNameInput') firstNameInput!: ElementRef;
  selectedRole: string = ''; // Define clientVerification property

  submitted: boolean = false; // Define submitted property only once
  registrationForm: FormGroup;
  // submitted = false;
  file: File | undefined;
  jwtHelper: any;
  UserID: any;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private registerService: RegisterService,
    private cookieService: CookieService
  ) {
    this.registrationForm = this.createRegistrationForm();
  }

  createRegistrationForm(): FormGroup {
    return this.fb.group({
      DisplayName: [
        '',
        [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(20),
        ],
      ],
      Email: ['', [Validators.required, Validators.email]],
      PhoneNumber: [
        '',
        [Validators.required, Validators.pattern(/^(010|011|012|015)\d{8}$/)],
      ],
      Address: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(30),
        ],
      ],
      NationalId: [
        '',
        [
          Validators.required,
          Validators.minLength(14),
          Validators.maxLength(14),
        ],
      ],
      PersonalImage: [null, [Validators.required]],
      Password: ['', [Validators.required, Validators.minLength(8)]],
      confirmPassword: ['', [Validators.required, passwordMatchValidator]],
    });
  }
  onRoleChange(event: any) {
    this.selectedRole = event.target.value;
  }
  onSubmit() {
    this.submitted = true;
    const password = this.registrationForm.get('Password')?.value;
    const confirmPassword = this.registrationForm.get('confirmPassword')?.value;

    if (password !== confirmPassword) {
      alert('The Password does not match with Confirm Password');
      return;
    }
    if (this.registrationForm.invalid) {
      return;
    }

    const formData = new FormData();

    // Append form field values to formData
    formData.append('DisplayName', this.registrationForm.value.DisplayName);
    formData.append('Email', this.registrationForm.value.Email);
    formData.append('PhoneNumber', this.registrationForm.value.PhoneNumber);
    formData.append('Address', this.registrationForm.value.Address);
    formData.append('NationalId', this.registrationForm.value.NationalId);
    formData.append('Password', this.registrationForm.value.Password);
    if (this.file) {
      // Append file data if available
      formData.append('personalImage', this.file);
      console.log('Selected Role:', this.selectedRole);
    }
    if (this.selectedRole === 'client') this.saveUserInApi(formData, '/Home');
    else if (this.selectedRole === 'herify')
      this.saveUserInApi(formData, '/regherify');
  }

  saveUserInApi(formData: FormData, endpoint: string) {
    let RoleId: number = 0;

    if (this.selectedRole === 'client') {
      RoleId = 3; // Assuming 3 represents the client role ID
    } else if (this.selectedRole === 'herify') {
      RoleId = 4; // Assuming 4 represents the Herify role ID
    }

    // Add userRoleID to formData
    formData.append('RoleId', RoleId.toString());

    this.registerService
      .CreateRegistration(formData)
      .pipe(
        concatMap((response: any) => {
          if (response && response.token) {
            const expiryMinutes = 60;
            this.cookieService.set(
              'authToken',
              response.token,
              expiryMinutes * 60
            );
            const token = this.cookieService.get('authToken');
            if (token) {
              const decodedToken: any = jwtDecode(token);
              this.UserID =
                decodedToken[
                  'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
                ];
            }
            console.log(this.UserID);
            const clientDto: any = {
              UserId: this.UserID,
            };
            // Return an observable for CreateClient
            return this.registerService.CreateClient(clientDto);
          }
          // If there is no token or an issue with the response, return an empty observable
          return EMPTY;
        })
      )
      .subscribe(
        (clientResponse: any) => {
          console.log('Registration successful!', clientResponse);
          alert('Registration as Client successful!');
          this.router.navigate([endpoint]);
        },
        (clientError) => {
          console.error('Client registration error:', clientError);
          alert('Client registration error:' + clientError);
        }
      );
  }

  onChange(event: any) {
    this.file =
      event.target.files && event.target.files.length > 0
        ? event.target.files.item(0)
        : undefined;
  }

  get formControls() {
    return this.registrationForm.controls;
  }
}
