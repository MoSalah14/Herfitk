import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-display-herfiys',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './display-herfiys.component.html',
  styleUrl: './display-herfiys.component.css',
})
export class DisplayHerfiysComponent implements OnInit {
  @Input() receivedHerfiys: any;

  constructor() {}

  ngOnInit(): void {
    console.log(this.receivedHerfiys); // This Come With Undefind I will solve it tommorow
  }
}
