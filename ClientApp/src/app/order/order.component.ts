import { Component, Input, Inject, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent {
  @Input() private order;
  @Output() public makeUpdate = new EventEmitter();

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  markAsComplete(): void {
    this.order.completed = true;
    this.http.put<Order>(this.baseUrl + 'api/Order/' + this.order.id, this.order).subscribe(result => { }, error => console.error(error));
    this.makeUpdate.emit(null);
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
