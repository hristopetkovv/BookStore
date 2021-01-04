import { Component, Input, OnInit } from '@angular/core';
import { CartProductDto } from '../_models/cart-product.dto';
import { BookService } from '../_services/book.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
  @Input() cartProduct: CartProductDto = new CartProductDto();

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
  }

  removeBook(bookId: number) {
    this.bookService.removeBook(bookId).subscribe();
    // location.reload();
  }

}
