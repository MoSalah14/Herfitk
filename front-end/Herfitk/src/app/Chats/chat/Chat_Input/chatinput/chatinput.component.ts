import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-chatinput',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    HttpClientModule,
    RouterModule,
    ReactiveFormsModule
  ],
  templateUrl: './chatinput.component.html',
  styleUrl: './chatinput.component.css'
})
export class ChatinputComponent implements OnInit {
  content:string='';
  @Output() contentemmiter=new EventEmitter();

   ngOnInit(): void {
   }
  

   submitform(){
    if(this.content.trim()!==""){
      this.contentemmiter.emit(this.content);
    }
    this.content='';
  }
}
