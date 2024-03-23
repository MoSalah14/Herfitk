import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { DataSharingService } from '../../../../data-sharing.service';
import { CommonModule } from '@angular/common';
import { routes } from '../../../../app.routes';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { MessagesComponent } from '../../showMessages/messages/messages.component';
import { ChatinputComponent } from '../../Chat_Input/chatinput/chatinput.component';
@Component({
  selector: 'app-private-chat',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    MessagesComponent,
    ChatinputComponent
  
  ],
  templateUrl: './private-chat.component.html',
  styleUrl: './private-chat.component.css'
})
export class PrivateChatComponent implements OnInit ,OnDestroy{
  @Input() touser='';
  //NgbActiveModal
  constructor(public activemodal:NgbActiveModal ,public service: DataSharingService)
   {

  }
  ngOnDestroy(): void {
this.service.closePrivateChatMessage(this.touser);
  }
  
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
sendmessage(content:string){
this.service.sendPrivateMessage(this.touser,content);
}
}
