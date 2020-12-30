import { Component, OnInit } from '@angular/core';
import { CartDto } from '../_models/cart.dto';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-cart-listing',
  templateUrl: './cart-listing.component.html',
  styleUrls: ['./cart-listing.component.css']
})
export class CartListingComponent implements OnInit {
  cart: CartDto = new CartDto();

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.showCart();
  }

  showCart() {
    this.userService.showCart().subscribe(cart => this.cart = cart);
  }
}
