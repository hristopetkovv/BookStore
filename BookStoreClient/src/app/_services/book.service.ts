import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookDetailsDto } from '../_models/book-details.dto';
import { BookFilterDto } from '../_models/book-filter.dto';
import { BookDto } from '../_models/book.dto';
import { UserDto } from '../_models/user.dto';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  getBooks(booksFilter: BookFilterDto): Observable<BookDto[]> {
    const params = { ...booksFilter };

    return this.http.get<BookDto[]>('api/book', { params });
  }

  getBookDetails(id: number): Observable<BookDetailsDto> {
    // const user = JSON.parse(localStorage.getItem('user')) as UserDto;
    // const headers = new HttpHeaders(`Authorization: Bearer ${user.token}`);

    return this.http.get<BookDetailsDto>(`api/book/` + id);
  }

  createComment(comment: string, id: number) {
    // const user = JSON.parse(localStorage.getItem('user')) as UserDto;
    // const headers = new HttpHeaders(`Authorization: Bearer ${user.token}`);

    return this.http.post(`api/book/${id}/comments`, { comment: comment });
  }
}
