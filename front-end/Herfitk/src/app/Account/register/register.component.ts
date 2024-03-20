import { Component } from '@angular/core';
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
  imports: [ReactiveFormsModule, CommonModule,FormsModule],
  providers: [RegisterService],
})
export class RegisterComponent {
  selectedRole: string = ''; // Define clientVerification property

  submitted: boolean = false; // Define submitted property only once
  registrationForm: FormGroup;
  // submitted = false;
  file: File | undefined;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private registerService: RegisterService
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
    }
    this.saveUserInApi(formData);
  }

  saveUserInApi(formData: FormData) {
    this.registerService.CreateRegistration(formData).subscribe(
      (response) => {
        console.log('Registration successful!', response);
        alert('Registration successful!');
        this.router.navigate(['/login']);
      },
      (error) => {
        console.error('Registration error:', error);
        alert(error); // Display the error message received from the API
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
