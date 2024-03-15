import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core'; // AfterViewInit, ViewChild
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
declare var $: any; // Declare jQuery

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css',
})
export class CategoryComponent implements OnInit {
  baseUrl = environment.apiUrl;
  httpClient = inject(HttpClient);
  Category: any = [];
  FetchCategory(): void {
    this.httpClient
      .get(this.baseUrl + 'Category/Getall')
      .subscribe((data: any) => {
        this.Category = data;
        console.log(this.Category);
      });
  }

  ngOnInit(): void {
    this.FetchCategory();
    $(document).ready(function () {
      $('.owl-carousel').owlCarousel({
        margin: 20,
        loop: true,
        // autoplay: true,
        // autoplayTimeout: 5000,
      });
    });
  }
}
