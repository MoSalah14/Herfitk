import { Component, OnInit, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-display-herfiys',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './display-herfiys.component.html',
  styleUrl: './display-herfiys.component.css',
})
export class DisplayHerfiysComponent implements OnInit {
  baseUrl = environment.apiUrl;
  AllHerify: any = [];

  constructor(private httpClient: HttpClient) {}

  ngOnInit(): void {
    this.fetchCategory('string');
  }

  fetchCategory(type: string): void {
    const url = `${this.baseUrl}Herify/HerfiySpeciality`;
    const headers = { type }; // Set the type parameter in the request header

    this.httpClient.get(url, { headers }).subscribe(
      (data: any) => {
        console.log(url);
        console.log(headers);
        this.AllHerify = data;
        console.log(this.AllHerify);
      },
      (error) => {
        console.error('Error fetching Herfiy:', error);
        // Handle error, e.g., show an error message to the user
      }
    );
  }
}
