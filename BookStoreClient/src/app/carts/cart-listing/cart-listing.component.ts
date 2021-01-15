import { Component, OnInit } from '@angular/core';
import { CartDto } from '../../_models/cart.dto';
import { CartService } from '../../_services/cart.service';
import { OrderService } from '../../_services/order.service';

@Component({
  selector: 'app-cart-listing',
  templateUrl: './cart-listing.component.html',
  styleUrls: ['./cart-listing.component.css']
})
export class CartListingComponent implements OnInit {
  cart: CartDto = new CartDto();

  constructor(private cartService: CartService, private orderService: OrderService) { }

  ngOnInit(): void {
    this.showCart();
  }

  showCart() {
    this.cartService.showCart().subscribe(cart => this.cart = cart);
  }

  completeOrder() {
    this.orderService.createOrder(this.cart.totalPrice).subscribe();
  }
}
