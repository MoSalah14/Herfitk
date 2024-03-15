import { Component,Output, EventEmitter } from '@angular/core';
import { RegisterComponent } from '../register/register.component';
import { Router, RouterModule } from '@angular/router';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RegisterComponent,RouterModule , FormsModule, CommonModule , ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  @Output() close: EventEmitter<void> = new EventEmitter<void>();

  closeLoginForm(): void {
    this.close.emit();
  }


  email: string = '';
  password: string = '';
  submitted: boolean = false;
  showEmailRequiredMessage: boolean = false;

  // constructor() { }
  constructor(private router:Router){}
  onSubmit() {
    this.submitted = true;
  }

  FormValdiation = new FormGroup({
    email: new FormControl("",[Validators.email]),
    password: new FormControl("",[Validators.minLength(8) , Validators.maxLength(12)])
  })

  get validEmail() {
      return this.FormValdiation.controls['email'].valid ;

  }
  get validPass() {
      return this.FormValdiation.controls['password'].valid
  }
  logSuc(email:any , password:any){

    if(!email || !password) {
      this.showEmailRequiredMessage = true;
    }
    if(this.FormValdiation.valid){
        alert( "login suc")
        this.router.navigate(['app']);

    }
  }

 
}
