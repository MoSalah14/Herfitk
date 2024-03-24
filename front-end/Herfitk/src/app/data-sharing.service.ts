import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { environment } from './environments/environment';
import { User } from './Chats/chat/models/User';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Message } from './Chats/chat/models/Message';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PrivateChatComponent } from './Chats/chat/PrivateChats/private-chat/private-chat.component';

@Injectable({
  providedIn: 'root',
})
export class DataSharingService {
  sharedObject: any;
  MyName: string = '';
  public chatconnection?: HubConnection;
  OnlinneUsers: string[] = [];
  messages: Message[] = [];
  privateMessages: Message[] = [];
  privateMessageInitial = false;
  URLAPI = environment.apiUrl;
  constructor(private myclient: HttpClient, private modalservice: NgbModal) {}

  getSharedObject(): any {
    return this.sharedObject;
  }
  getherifybyid(id: any) {
    return this.myclient.get(`${this.URLAPI}Herify/${id}`);
  }
  getreviewherify(id: number) {
    return this.myclient.get(this.URLAPI + 'ClientHerifies/GetAll/' + id);
  }

  SendReview(Obj: any) {
    return this.myclient.post(`${this.URLAPI}ClientHerifies/Create`, Obj);
  }

  registeruser(user: User) {
    return this.myclient.post(this.URLAPI + 'Chat/register-user', user, {
      responseType: 'text',
    });
  }
  createchatconnection() {
    this.chatconnection = new HubConnectionBuilder()
      .withUrl('https://localhost:44346/hubs/chat')
      .withAutomaticReconnect()
      .build();

    this.chatconnection.start().catch((error) => {
      console.log(error);
    });
    //receiving commands from Chathub
    this.chatconnection.on('UserConnected', () => {
      this.adduserconnectionid();
    });

    this.chatconnection.on('OnlinneUsers', (OnlinneUsers) => {
      this.OnlinneUsers = [...OnlinneUsers];
    });
    this.chatconnection.on('NewMessage', (newMessage: Message) => {
      this.messages = [...this.messages, newMessage];
    });
    this.chatconnection.on('OpenPrivateChat', (newMessage: Message) => {
      this.privateMessages = [...this.privateMessages, newMessage];
      this.privateMessageInitial = true;
      const modalRef = this.modalservice.open(PrivateChatComponent);
      modalRef.componentInstance.touser = newMessage.from;
    });

    this.chatconnection.on('RecievePrivateMessage', (newMessage: Message) => {
      this.privateMessages = [...this.privateMessages, newMessage];
    });
    this.chatconnection.on('NewPrivateMessage', (newMessage: Message) => {
      this.privateMessages = [...this.privateMessages, newMessage];
    });
    this.chatconnection.on('ClosePrivateChat', () => {
      this.privateMessageInitial = false;
      this.privateMessages = [];
      this.modalservice.dismissAll();
    });
  }
  stopchatconnection() {
    this.chatconnection?.stop().catch((error) => {
      console.log(error);
    });
  }
  async adduserconnectionid() {
    return this.chatconnection
      ?.invoke('Adduserconnectionid', this.MyName)
      .catch((error) => console.log(error));
  }
  async SendMessage(content: string) {
    const message: Message = {
      from: this.MyName,
      content,
    };
    return this.chatconnection
      ?.invoke('ReceiveMessage', message)
      .catch((error) => console.log(error));
  }
  async sendPrivateMessage(to: string, content: string) {
    const message: Message = {
      from: this.MyName,
      to,
      content,
    };
    if (!this.privateMessageInitial) {
      this.privateMessageInitial = true;
      return this.chatconnection
        ?.invoke('CreatePrivateChat', message)
        .then(() => {
          this.privateMessages = [...this.privateMessages, message];
        })
        .catch((error) => console.log(error));
    } else {
      return this.chatconnection
        ?.invoke('RecievePrivateMessage', message)
        .catch((error) => console.log(error));
    }
  }
  async closePrivateChatMessage(otheruser: string) {
    return this.chatconnection
      ?.invoke('RecievePrivateMessage', this.MyName, otheruser)
      .catch((error) => console.log(error));
  }
}
