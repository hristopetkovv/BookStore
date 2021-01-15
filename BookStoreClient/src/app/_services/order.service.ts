import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderDto } from '../_models/order.dto';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }

  createOrder(totalPrice: number) {
    return this.http.post('api/order', totalPrice);
  }

  getOrders(): Observable<OrderDto[]> {
    return this.http.get<OrderDto[]>('api/order');
  }
}
