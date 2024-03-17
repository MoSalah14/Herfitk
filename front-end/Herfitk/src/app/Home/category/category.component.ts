import { CommonModule } from '@angular/common';
import { Component, EventEmitter, OnInit, Output, inject } from '@angular/core'; // AfterViewInit, ViewChild
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router, RouterModule } from '@angular/router';
declare var $: any; // Declare jQuery

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css',
})
export class CategoryComponent implements OnInit {
  constructor(private router: Router, private httpClient: HttpClient) {}
  @Output() MyEvent = new EventEmitter();
  baseUrl = environment.apiUrl;
  Category: any = [];
  Herfiys: any = [];
  categoryid: any;
  FetchCategory(): void {
    this.httpClient
      .get(this.baseUrl + 'Category/Getall')
      .subscribe((data: any) => {
        this.Category = data;
        console.log(this.Category);
      });
  }

  GetHerfiyByCategory(catId: number) {
    this.httpClient
      .get(`${this.baseUrl}HerifyCategories/${catId}`)
      .subscribe((obj: any) => {
        this.Herfiys = obj;
        this.MyEvent.emit(this.Herfiys);
        console.log(this.Herfiys);
      });
  }

  ngOnInit(): void {
    this.FetchCategory();
    this.GetHerfiyByCategory(this.categoryid);

    $(document).ready(function () {
      $('.owl-carousel').owlCarousel({
        margin: 20,
        loop: true,
        // autoplay: true,
        // autoplayTimeout: 5000,
      });
    });
  }

  GOto() {
    this.router.navigate(['/Display']);
  }
}
