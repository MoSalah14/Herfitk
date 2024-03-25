import { AfterViewInit, Component, ElementRef, EventEmitter, OnDestroy, OnInit, Output, ViewChild, viewChild } from '@angular/core';
import { DataSharingService } from '../../../../data-sharing.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ChatinputComponent } from '../../Chat_Input/chatinput/chatinput.component';
import { MessagesComponent } from '../../showMessages/messages/messages.component';
import { User } from '../../models/User';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PrivateChatComponent } from '../../PrivateChats/private-chat/private-chat.component';

@Component({
  selector: 'app-chat-home',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule,
    ReactiveFormsModule,
    ChatinputComponent,
    MessagesComponent,
    FormsModule
  ],
  templateUrl: './chat-home.component.html',
  styleUrl: './chat-home.component.css'
})
export class ChatHomeComponent implements OnInit ,OnDestroy ,AfterViewInit{
   @Output() CloseChatEmiter=new EventEmitter();
   touser:string='';
   @ViewChild('exampleModal',{static:false}) exampleModal?:ElementRef<HTMLElement>;

 
constructor(public service:DataSharingService ,private modalservice:NgbModal) {}
  ngAfterViewInit(): void {
    throw new Error('Method not implemented.');
  }

  ngOnDestroy(): void {
    this.service.stopchatconnection();
    throw new Error('Method not implemented.');
  }
  ngOnInit(): void {
    this.service.createchatconnection();
  }
  backtohome(){
this.CloseChatEmiter.emit();
}
sendmessage(content:string){
  this.service.SendMessage(content);
}

sendprivatemessage(contentprivate:string){
  this.service.sendPrivateMessage(this.service.MyName,contentprivate);

}
openPrivateChat(touser:string){
  console.log("hiiii");
//const modalref=this.modalservice.open(PrivateChatComponent);
const modalRef = this.modalservice.open(PrivateChatComponent, { size: 'lg' });
modalRef.componentInstance.touser=touser;
}

Close(){
  (this.exampleModal?.nativeElement as HTMLElement).style.display='none';
   document.body.classList.remove('modal-open');
}

open(){
  (this.exampleModal?.nativeElement as HTMLElement).style.display='block';
  document.body.classList.add('modal-open');
}


}
