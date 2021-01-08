import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BookDetailsDto } from '../_models/book-details.dto';
import { BookFilterDto } from '../_models/book-filter.dto';
import { BookDto } from '../_models/book.dto';
import { PaginatedResult } from '../_models/pagination.dto';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  paginatedResult: PaginatedResult<BookDto[]> = new PaginatedResult<BookDto[]>();

  constructor(private http: HttpClient) { }

  getBooks(booksFilter: BookFilterDto, page?: number, itemsPerPage?: number): Observable<PaginatedResult<BookDto[]>> {
    let params = new HttpParams();

    if (page !== null && itemsPerPage !== null) {
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
    }

    return this.http.get<BookDto[]>(`api/book/${booksFilter.getQueryString()}`, { observe: 'response', params }).pipe(
      map(response => {
        this.paginatedResult.result = response.body;
        if (response.headers.get('Pagination') !== null) {
          this.paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }

        return this.paginatedResult;
      })
    );
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
