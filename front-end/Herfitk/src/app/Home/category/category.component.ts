
import { CommonModule } from '@angular/common';
import { Component , OnInit  } from '@angular/core'; // AfterViewInit, ViewChild
declare var $: any; // Declare jQuery

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    $(document).ready(function(){
      $(".owl-carousel").owlCarousel({
        
        margin: 20,
        loop: true,
        // autoplay: true,
        // autoplayTimeout: 5000,
      
      });
    });
  }

}
