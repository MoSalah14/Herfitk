import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, NgModule, OnInit } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { DataSharingService } from '../../data-sharing.service';
import { concatWith } from 'rxjs';

@Component({
  selector: 'app-viewprofile',
  standalone: true,
  imports: [
    RouterModule,
    ReactiveFormsModule,
    HttpClientModule,
    CommonModule
  ],
  providers:[
    DataSharingService
  ],
  templateUrl: './viewprofile.component.html',
  styleUrl: './viewprofile.component.css'
})
export class ViewprofileComponent implements OnInit {
  ID=0;
  profile:any;
  reviews:any;
constructor(private myid:ActivatedRoute,private service:DataSharingService){
this.ID=myid.snapshot.params["id"];
}
  ngOnInit(): void {
   this.service.getherifybyid(this.ID).subscribe({
  next:(info)=>{
    this.profile=info;
    console.log(this.profile);
   },
   error:(err)=>{
    console.log(err);
   }
  });
  this.service.getreviewherify().subscribe({
    next:(info)=>{
     this.reviews=info;
     console.log(this.reviews);
    },
    error:(err)=>{
      console.log(err);
    }
  })

  }
}
