import { Component, Input, OnInit } from '@angular/core';
import { CartProductDto } from '../_models/cart-product.dto';
import { CartService } from '../_services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
  @Input() cartProduct: CartProductDto = new CartProductDto();

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
  }

  removeBook(bookId: number) {
    this.cartService.removeBook(bookId).subscribe();
    location.reload();
  }
}
