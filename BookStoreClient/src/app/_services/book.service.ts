import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookDetailsDto } from '../_models/book-details.dto';
import { BookFilterDto } from '../_models/book-filter.dto';
import { BookDto } from '../_models/book.dto';
import { SearchResultDto } from '../_models/pagination.dto';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  constructor(
    private http: HttpClient
  ) { }

  getBooks(booksFilter: BookFilterDto): Observable<SearchResultDto<BookDto>> {
    return this.http.get<SearchResultDto<BookDto>>(`api/book/${booksFilter.getQueryString()}`);
  }

  getBookDetails(id: number): Observable<BookDetailsDto> {
    return this.http.get<BookDetailsDto>(`api/book/` + id);
  }

  createComment(comment: string, id: number) {
    return this.http.post(`api/book/${id}/comments`, { comment: comment });
  }

  buyBook(id: number, pieces: number) {
    return this.http.post(`api/book/${id}`, pieces);
  }


}
