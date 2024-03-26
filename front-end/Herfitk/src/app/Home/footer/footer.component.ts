import { Component,OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css'
})
export class FooterComponent  implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  navigateToChat(): void {
    this.router.navigate(['/chat']); // Navigate to the chat page
  }
}
