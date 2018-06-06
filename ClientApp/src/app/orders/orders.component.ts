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
    this.orders = this.orders.sort(this.sortByCompletedThenByRecieved);
    console.log(this.orders[0].timeRecieved);
  }

  sortByCompletedThenByRecieved(a: Order, b: Order): number {
    return ((a.completed === b.completed) ? 0 : (a.completed ? 1 : -1)) ||
      new Date(a.timeRecieved).getTime() - new Date(b.timeRecieved).getTime();
  }

  public trackOrder(index: number, order: Order): number | null {
    return order.id;
  }
}
