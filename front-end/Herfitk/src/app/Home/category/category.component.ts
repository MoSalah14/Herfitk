import { CommonModule } from '@angular/common';
import { Component, EventEmitter, OnInit, Output, inject } from '@angular/core'; // AfterViewInit, ViewChild
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router, RouterModule } from '@angular/router';
import { DataSharingService } from '../../data-sharing.service';
import { TranslateModule } from '@ngx-translate/core';
declare var $: any; // Declare jQuery

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [CommonModule, RouterModule, TranslateModule],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css',
})
export class CategoryComponent  {

  constructor(
    private router: Router,
    private httpClient: HttpClient,
    private dataSharingService: DataSharingService
  ) {this.FetchCategory();}
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
  goToDisplay(id: number) {
    this.router.navigate(['/display', id]);
  }
}
