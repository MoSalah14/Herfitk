import { CommonModule } from '@angular/common';
import { Component,OnInit } from '@angular/core';
import { UserService } from './user.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-userprofile',
  standalone: true,
  imports: [CommonModule,RouterModule],
  templateUrl: './userprofile.component.html',
  styleUrl: './userprofile.component.css',
  providers: [UserService],
})
export class UserprofileComponent implements OnInit {
  userData: any;

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.fetchUserData();
  }

  fetchUserData(): void {
    this.userService.getUserData().subscribe(
      (data: any) => {
        this.userData = data;
        console.log(data);
      },
      (error: any) => {
        console.error('Failed to fetch user data:', error);
      }
    );
  }
}
