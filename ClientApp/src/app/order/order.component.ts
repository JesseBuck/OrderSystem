import { Component, Input } from '@angular/core';
import { OrdersComponent } from '../orders/orders.component';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent {
  @Input() order;

  constructor() { }
}
