import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CartDto } from '../_models/cart.dto';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private http: HttpClient) { }

  showCart(): Observable<CartDto> {
    return this.http.get<CartDto>('api/cart');
  }

  removeBook(bookId: number) {
    return this.http.delete(`api/Cart/${bookId}`);
  }
}
