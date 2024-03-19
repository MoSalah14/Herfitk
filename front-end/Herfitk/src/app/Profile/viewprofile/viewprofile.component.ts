import { Component } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-viewprofile',
  standalone: true,
  imports: [
    RouterModule,
    ReactiveFormsModule
    
  
  ],
  templateUrl: './viewprofile.component.html',
  styleUrl: './viewprofile.component.css'
})
export class ViewprofileComponent {

}
