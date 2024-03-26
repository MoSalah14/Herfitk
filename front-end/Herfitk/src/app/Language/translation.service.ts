import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root',
})
export class TranslationService {
  constructor(private translate: TranslateService) {}

  setDefaultLanguage(language: string) {
    this.translate.setDefaultLang(language);
  }

  ChangeLanguage(language: string) {
    this.translate.use(language);
  }
}
