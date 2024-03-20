import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { RegHerifyService } from './reg-herify.service';

@Component({
  selector: 'app-regs-herify',
  standalone: true,
  imports: [CommonModule, RouterModule, ReactiveFormsModule, FormsModule],
  templateUrl: './regs-herify.component.html',
  styleUrl: './regs-herify.component.css',
  providers: [RegHerifyService],
})
export class RegsHerifyComponent {
  FormValidation: FormGroup;
  file: File | undefined;

  constructor(
    private formBuilder: FormBuilder,
    private Service: RegHerifyService,
    private router: Router
  ) {
    this.FormValidation = this.formBuilder.group({
      Zone: ['', [Validators.required]],
      History: ['', Validators.required],
      Specialist: ['', Validators.required],
    });
  }

  get formControls() {
    return this.FormValidation.controls;
  }

  onSubmit() {
    if (this.FormValidation.invalid) {
      this.FormValidation.markAllAsTouched();
      return;
    }
    console.log('Form Data:', this.FormValidation.value);
    const formData = this.buildFormData();
    this.Service.CreateHerify(formData).subscribe(
      (response) => {
        console.log('Registration successful!', response);
        alert('Registration successful!');
        this.router.navigate(['/Home']);
      },
      (error) => {
        console.error('Registration error:', error);
        alert(error); // Display the error message received from the API
      }
    );
  }

  private buildFormData(): FormData {
    const formData = new FormData();
    formData.append('Zone', this.FormValidation.value.Zone);
    formData.append('History', this.FormValidation.value.History);
    formData.append('Specialist', this.FormValidation.value.Specialist);
    if (this.file) {
      formData.append('file', this.file);
    }
    return formData;
  }

  onChange(event: any) {
    if (event.target.files && event.target.files.length > 0) {
      this.file = event.target.files.item(0);
    } else {
      this.file = undefined; // Handle case where file input is cleared
    }
  }
}
