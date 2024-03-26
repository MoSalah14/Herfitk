import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, NgModule, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { DataSharingService } from '../../data-sharing.service';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../../app.routes';
import { ChatHomeComponent } from './NGCChat/chat-home/chat-home.component';

@Component({
  selector: 'app-chat',
  standalone: true,
  imports: [
  RouterModule,
  CommonModule,
  ReactiveFormsModule,
  HttpClientModule,
  FormsModule,
  ChatHomeComponent

  ],
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.css'
})
export class ChatComponent implements OnInit {
  myform:FormGroup=new FormGroup({});
  submitted=true;
  apierrormessage:[]=[];
  openchat=true;


  constructor(private formbilder:FormBuilder,private service:DataSharingService){

  }
  ngOnInit(): void {
this.initializeform();
  }
initializeform(){
  this.myform=this.formbilder.group({
    name:new FormControl("",[Validators.required,Validators.min(3)]),

  })    
      // email:new FormControl("",[Validators.required,Validators.email]),
      // age:new FormControl(null,[Validators.min(10),Validators.max(30)])
}
submitform(){
  this.submitted=true;
if(this.myform.valid){
 this.service.registeruser(this.myform.value).subscribe({
next:()=>{
  this.service.MyName=this.myform.get('name')?.value;
this.openchat=true;
this.myform.reset();
this.submitted=false;
},
error:(error)=>{
  //  if(typeof(error.error) !=='object'){
  //   this.apierrormessage.push(error.error);
  //  }
  console.log("Error in chat");
}
 });
  // console.log(this.myform.value);
}
}

CloseChat(){
  this.openchat=false;

}
}
