import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookDetailsDto } from '../_models/book-details.dto';
import { BookDto } from '../_models/book.dto';
import { UserDto } from '../_models/user.dto';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  getBooks(): Observable<BookDto[]> {
    return this.http.get<BookDto[]>('api/book');
  }

  getBookDetails(id: number): Observable<BookDetailsDto> {
    const user = JSON.parse(localStorage.getItem('user')) as UserDto;
    const headers = new HttpHeaders(`Authorization: Bearer ${user.token}`);
    return this.http.get<BookDetailsDto>(`api/book/` + id, { headers: headers });
  }

  createComment(comment: string, id: number) {
    const user = JSON.parse(localStorage.getItem('user')) as UserDto;
    const headers = new HttpHeaders(`Authorization: Bearer ${user.token}`);
    debugger;
    return this.http.post(`api/book/${id}/comments`, { comment: comment }, { headers: headers });
  }
}
