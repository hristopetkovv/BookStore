import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CartDto } from '../_models/cart.dto';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  showCart(): Observable<CartDto> {
    return this.http.get<CartDto>('api/Home');
  }

  removeBook(bookId: number) {
    return this.http.delete(`api/Home/${bookId}`);
  }
}
