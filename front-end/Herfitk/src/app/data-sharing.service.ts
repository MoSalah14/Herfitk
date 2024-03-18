import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class DataSharingService {
  sharedObject: any;

  constructor() {}

  getSharedObject(): any {
    return this.sharedObject;
  }
}
