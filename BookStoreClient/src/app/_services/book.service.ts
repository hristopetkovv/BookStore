import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookDto } from '../_models/bookDto';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  getBooks(): Observable<BookDto[]> {
    return this.http.get<BookDto[]>('api/book');
  }

  getDetailOfBook(id: number) {
    return this.http.get(`api/book/` + id);
  }
}
