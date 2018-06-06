import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderComponent, Order, OrderItem } from '../order/order.component';

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
      this.sortOrders();
    }, error => console.error(error));
  }

  onUpdate(): void {
    this.sortOrders();
  }

  sortOrders(): void {
    this.orders = this.orders
      .sort((a, b) => (a.completed === b.completed) ? 0 : (a.completed ? 1 : -1))
      .sort((a, b) => (a.timeRecieved.getTime() - b.timeRecieved.getTime()));
  }

  public trackOrder(index: Number, order: Order): Number | null {
    return order.id;
  }
}
