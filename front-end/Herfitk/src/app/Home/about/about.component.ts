import { Component } from '@angular/core';
import { RouterLink, RouterModule } from '@angular/router';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { AppComponent } from '../../app.component';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [RouterLink, RouterModule, TranslateModule, AppComponent],
  templateUrl: './about.component.html',
  styleUrl: './about.component.css',
})
export class AboutComponent {
  constructor(private languageService: TranslateService) {}

  ngOnInit() {
    this.languageService.setDefaultLang('en');
  }

  switchLanguage(language: string) {
    this.languageService.use(language); // Use 'use' instead of 'ChangeLanguage'
  }
}
