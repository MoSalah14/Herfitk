import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataSharingService } from '../../data-sharing.service';
import { HttpClient, HttpClientModule, HttpParams } from '@angular/common/http';
import { ActivatedRoute, RouterModule, Router } from '@angular/router';
import { environment } from '../../environments/environment';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
// import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-display-herfiys',
  standalone: true,
  imports: [CommonModule, RouterModule, /*HttpClientModule,*/ TranslateModule],
  templateUrl: './display-herfiys.component.html',
  styleUrl: './display-herfiys.component.css',
})
export class DisplayHerfiysComponent implements OnInit {
  herfiys: any[] = [];
  apiUrl = environment.apiUrl;

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient,
    private router: Router
  ) {
    // this.translateService.setDefaultLang('en');
  }

  // SwitchLanguage(language: string) {
  //   this.translateService.use(language);
  // }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      const id = params['id'];
      console.log('ID from URL:', id);
      this.getHerfiysByCategory(id);
    });
  }

  getHerfiysByCategory(
    categoryId: number,
    pageIndex: number = 1,
    pageSize: number = 5
  ) {
    let params = new HttpParams()
      .set('categoryId', categoryId.toString())
      .set('PageIndex', pageIndex.toString())
      .set('PageSize', pageSize.toString());

    this.http
      .get<any[]>(`${this.apiUrl}HerifyCategories`, { params })
      .subscribe((data) => {
        this.herfiys = data;
        console.log('Herfiys:', this.herfiys);
      });
  }

  goToDisplay(id: number) {
    this.router.navigate(['/profile', id]);
  }
}
