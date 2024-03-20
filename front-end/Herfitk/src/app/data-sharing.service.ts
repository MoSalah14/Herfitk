import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from './environments/environment';

@Injectable({
  providedIn: 'root',
})
export class DataSharingService {
  sharedObject: any;
  URLAPI=environment.apiUrl;
  constructor(private myclient:HttpClient) {}

  getSharedObject(): any {
    return this.sharedObject;
  }
  getherifybyid(id:any){
    return this.myclient.get(this.URLAPI+'Herify'+'/' +id);
  }
  getreviewherify(){
    return this.myclient.get(this.URLAPI+'ClientHerifies');
  }

}
