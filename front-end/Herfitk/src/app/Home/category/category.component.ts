import { CommonModule } from '@angular/common';
import { Component, EventEmitter, OnInit, Output, inject } from '@angular/core'; // AfterViewInit, ViewChild
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router, RouterModule } from '@angular/router';
import { DataSharingService } from '../../data-sharing.service';
declare var $: any; // Declare jQuery

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css',
})
export class CategoryComponent implements OnInit {
  constructor(
    private router: Router,
    private httpClient: HttpClient,
    private dataSharingService: DataSharingService
  ) {}
  @Output() MyEvent = new EventEmitter();
  baseUrl = environment.apiUrl;
  Category: any = [];
  categoryid: any;

  // Get ALl Categories
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

  goToDisplay(id: number) {
    this.router.navigate(['/display', id]);
  }
}
