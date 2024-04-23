import {
  Component,
  Output,
  EventEmitter,
  HostListener,
  ElementRef,
} from '@angular/core';
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
import { TranslateModule, TranslateService } from '@ngx-translate/core';

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
    TranslateModule,
  ],
  providers: [LoginService, CookieService],
})
export class LoginComponent {
  @Output() close: EventEmitter<void> = new EventEmitter<void>();

  // Declare the submitted property
  submitted: boolean = false;
  showEmailRequiredMessage: boolean = false;
  errorText: string | null = null;

  constructor(
    private router: Router,
    private loginService: LoginService,
    private fb: FormBuilder,
    private cookieService: CookieService,
    private elementRef: ElementRef,
    private translate: TranslateService
  ) {
    this.FormValidation = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
    this.translate.setDefaultLang;
    ('en');
  }
  SwitchLanguage(language: string) {
    this.translate.use(language);
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
  @HostListener('document:click', ['$event'])
  handleClick(event: MouseEvent) {
    if (!this.elementRef.nativeElement.contains(event.target)) {
      this.closeLoginForm();
    }
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
          if (response && response.token) {
            console.log(response);

            this.cookieService.set('authToken', response.token, 60 / (24 * 60)); // 60 minutes converted to days

            this.router.navigate(['Home']);
            setTimeout(() => {
              window.location.reload();
            }, 1000);
          }
        },
        error: (error) => {
          console.error(error.error.message);
          this.errorText = error.error.message;
        },
      });
    }
    this.submitted = true;
  }

  closeLoginForm(): void {
    this.close.emit();
  }
}
