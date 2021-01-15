import { Component, OnInit } from '@angular/core';
import { OrderDto } from 'src/app/_models/order.dto';
import { OrderService } from 'src/app/_services/order.service';

@Component({
  selector: 'app-order-listing',
  templateUrl: './order-listing.component.html',
  styleUrls: ['./order-listing.component.css']
})
export class OrderListingComponent implements OnInit {
  orders: OrderDto[] = [];
  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders() {
    this.orderService.getOrders().subscribe(orders => this.orders = orders);
  }

}
