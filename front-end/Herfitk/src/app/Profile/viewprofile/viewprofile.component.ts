import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, Directive, NgModule, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, RouterLink, RouterModule } from '@angular/router';
import { DataSharingService } from '../../data-sharing.service';
import { concatWith } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';
import { JWT_OPTIONS, JwtHelperService } from '@auth0/angular-jwt';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-viewprofile',
  standalone: true,
  imports: [
    RouterModule,
    ReactiveFormsModule,
    HttpClientModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterLink,
    TranslateModule,
  ],
  providers: [
    DataSharingService,
    CookieService,
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
    JwtHelperService,
  ],
  templateUrl: './viewprofile.component.html',
  styleUrl: './viewprofile.component.css',
})
export class ViewprofileComponent implements OnInit {
  ID = 0;
  profile: any;
  alldata: any;
  reviews: any;
  UserRole: any;

  rating: number = 0;
  feedbackText: string = '';
  userRole: any;
  Errormessage: string = '';

  constructor(
    private myid: ActivatedRoute,
    private service: DataSharingService,
    private cookieService: CookieService,
    private jwtHelper: JwtHelperService
  ) {
    this.ID = myid.snapshot.params['id'];
  }
  ngOnInit(): void {
    this.myid.params.subscribe((params) => {
      console.log(params); //Display Error If Routing Not Working
      this.ID = params['id'];
      this.GetDataFromAPi();
    });
  }

  GetDataFromAPi(): void {
    this.service.getherifybyid(this.ID).subscribe({
      next: (info) => {
        this.profile = info;
      },
      error: (err) => {
        console.log(err);
      },
    });
    this.service.getreviewherify(this.ID).subscribe({
      next: (info) => {
        this.alldata = info;
        console.log(this.alldata);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  submitFeedback(): void {
    const authToken = this.cookieService.get('authToken');
    if (authToken) {
      const decodedToken = this.jwtHelper.decodeToken(authToken);
      console.log(decodedToken);

      this.userRole = decodedToken['UserRole'];
      console.log(this.userRole);

      if (this.userRole === '3') {
        const feedbackData = {
          HerifyID: this.ID,
          ClientId:
            decodedToken[
              'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
            ],
          Rate: this.rating,
          Review: this.feedbackText,
        };
        // Dont Forget Handle Messages
        this.service.SendReview(feedbackData).subscribe(
          () => {
            alert((this.Errormessage = 'Feedback submitted successfully!'));
          },
          () => {
            this.Errormessage = 'Error submitting feedback. Please try again.';
          }
        );
      } else {
        this.Errormessage = 'Your Account Cant Review ';
      }
    } else {
      this.Errormessage = 'Please Login First';
    }
  }
}
