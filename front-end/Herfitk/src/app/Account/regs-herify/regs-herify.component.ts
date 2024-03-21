import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { RegHerifyService } from './reg-herify.service';
import { CookieService } from 'ngx-cookie-service';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-regs-herify',
  standalone: true,
  imports: [CommonModule, RouterModule, ReactiveFormsModule, FormsModule],
  templateUrl: './regs-herify.component.html',
  styleUrl: './regs-herify.component.css',
  providers: [RegHerifyService],
})
export class RegsHerifyComponent implements OnInit {
  FormValidation: FormGroup;
  file: File | undefined;
  userId: string | null = null;
  CategoryName: any[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private service: RegHerifyService,
    private router: Router,
    private cookieService: CookieService
  ) {
    this.FormValidation = this.formBuilder.group({
      Zone: ['', [Validators.required]],
      History: ['', Validators.required],
      Speciality: ['', Validators.required],
      CategoryName: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.getUserIdFromToken();
    this.fetchCategories();
  }

  fetchCategories(): void {
    this.service.FetchCategory().subscribe(
      (data) => {
        this.CategoryName = data;
        console.log('Fetched Categories:', this.CategoryName);
      },
      (error) => {
        console.error('Error fetching categories:', error);
      }
    );
  }

  getUserIdFromToken(): void {
    const token = this.cookieService.get('authToken');
    if (token) {
      const decodedToken: any = jwtDecode(token);
      this.userId =
        decodedToken[
          'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
        ];
    }
  }

  get formControls() {
    return this.FormValidation.controls;
  }

  onSubmit(): void {
    if (this.FormValidation.invalid) {
      this.FormValidation.markAllAsTouched();
      return;
    }

    const formData = this.buildFormData();

    this.service.CreateHerify(formData).subscribe(
      (response) => {
        console.log('Registration successful!', response);
        this.handleRegistrationSuccess();
      },
      (error) => {
        console.error('Registration error:', error);
        alert('An error occurred during registration. Please try again later.');
      }
    );
  }

  private handleRegistrationSuccess(): void {
    this.service.FetchIDs().subscribe(
      (idsResponse) => {
        const herifyId = idsResponse;
        console.log(herifyId);

        const categoryId = this.FormValidation.value.CategoryName;
        const obj = {
          HerifyID: herifyId,
          CategoryID: categoryId,
        };
        console.log('Object to add:', obj);
        this.addHerifyCategory(obj);
      },
      (error) => {
        console.error('Error fetching IDs:', error);
      }
    );
  }

  private addHerifyCategory(obj: any): void {
    this.service.AddHerifyCategory(obj).subscribe(
      (response) => {
        console.log(obj);
        console.log('Added to herifyCategory:', response);
        this.router.navigate(['/Home']);
      },
      (error) => {
        console.log(obj);

        console.error('Error adding to herifyCategory:', error);
      }
    );
  }

  private buildFormData(): FormData {
    const formData = new FormData();
    formData.append('Zone', this.FormValidation.value.Zone);
    formData.append('History', this.FormValidation.value.History);
    formData.append('Speciality', this.FormValidation.value.Speciality);
    if (this.file) {
      formData.append('Image', this.file);
    }
    if (this.userId) {
      formData.append('HerifyUserID', this.userId);
    }
    return formData;
  }

  onChange(event: any): void {
    if (event.target.files && event.target.files.length > 0) {
      this.file = event.target.files.item(0);
    } else {
      this.file = undefined;
    }
  }
}
