import { Component, Input, OnInit } from '@angular/core';
import { CartProductDto } from '../_models/cart-product.dto';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
  @Input() cartProduct: CartProductDto = new CartProductDto();

  constructor(private userService: UserService) { }

  ngOnInit(): void {
  }

  removeBook(bookId: number) {
    this.userService.removeBook(bookId).subscribe();
    location.reload();
  }

}
