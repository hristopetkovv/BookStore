import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookDetailsDto } from '../_models/book-details.dto';
import { BookDto } from '../_models/book.dto';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  getBooks(): Observable<BookDto[]> {
    return this.http.get<BookDto[]>('api/book');
  }

  getBookDetails(id: number): Observable<BookDetailsDto> {
    return this.http.get<BookDetailsDto>(`api/book/` + id);
  }
}
