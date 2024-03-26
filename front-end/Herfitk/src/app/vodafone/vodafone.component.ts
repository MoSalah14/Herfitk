import { Component } from '@angular/core';
import { PaymentService } from '../payment.service';

@Component({
  selector: 'app-vodafone',
  standalone: true,
  imports: [],
  templateUrl: './vodafone.component.html',
  styleUrl: './vodafone.component.css',
})
export class VodafoneComponent {
  constructor(private paymentService: PaymentService) {}

  VodafoneRequest(): void {
    this.paymentService.VodafonerRequest(); // Call the service method
  }
}
