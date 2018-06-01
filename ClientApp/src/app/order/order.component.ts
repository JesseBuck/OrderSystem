import { Component, Input, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
// import { OrdersComponent } from '../orders/orders.component';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent {
  @Input() private order;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  markAsComplete() {
    this.order.completed = true;
    this.http.put<Order>(this.baseUrl + 'api/Order/' + this.order.id, this.order).subscribe(result => { }, error => console.error(error));
  }
}

export interface Order {
  id: Number;
  timeRecieved: Date;
  started: Boolean;
  completed: Boolean;
  customerName: String;
  destinationAddress: String;
  cost: Number;
  orderItems: Array<OrderItem>;
}

export interface OrderItem {
  id: Number;
  name: String;
  customerNote: String;
}
