import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent {
  public orders: Order[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Order[]>(baseUrl + 'api/Order').subscribe(result => {
      this.orders = result;
    }, error => console.error(error));
  }
}

interface Order {
  id: Number;
  timeRecieved: Date;
  started: Boolean;
  completed: Boolean;
  customerName: String;
  destinationAddress: String;
  cost: Number;
  orderItems: Array<OrderItem>;
}

interface OrderItem {
  id: Number;
  name: String;
  customerNote: String;
}
