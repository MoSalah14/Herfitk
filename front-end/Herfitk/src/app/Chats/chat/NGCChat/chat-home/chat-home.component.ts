import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { DataSharingService } from '../../../../data-sharing.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
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
    MessagesComponent
  ],
  templateUrl: './chat-home.component.html',
  styleUrl: './chat-home.component.css'
})
export class ChatHomeComponent implements OnInit ,OnDestroy{
   @Output() CloseChatEmiter=new EventEmitter();

constructor(public service:DataSharingService ,private modalservice:NgbModal) {}

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
openPrivateChat(touser:string){
const modalref=this.modalservice.open(PrivateChatComponent);
modalref.componentInstance.touser=touser;
}
}
