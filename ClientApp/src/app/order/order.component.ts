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
    this.order.timeCompleted = Date.now();
    this.http.put<Order>(this.baseUrl + 'api/Order/' + this.order.id, this.order).subscribe(result => { }, error => console.error(error));
    this.makeUpdate.emit(null);
  }
}

export interface Order {
  id: number;
  timeRecieved: string;
  started: boolean;
  completed: boolean;
  timeCompleted: string;
  customerName: string;
  destinationAddress: string;
  cost: number;
  orderItems: OrderItem[];
}

export interface OrderItem {
  id: number;
  name: string;
  customerNote: string;
}
