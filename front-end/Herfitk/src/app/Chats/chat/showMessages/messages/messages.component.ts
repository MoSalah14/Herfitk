import { Component, Input } from '@angular/core';
import { Message } from '../../models/Message';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-messages',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    // HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './messages.component.html',
  styleUrl: './messages.component.css'
})
export class MessagesComponent {
@Input() messages:Message[]=[];

}
