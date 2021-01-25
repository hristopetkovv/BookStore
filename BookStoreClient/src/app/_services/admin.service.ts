import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddBookDto } from '../_models/add-book.dto';
import { BookUpdateDto } from '../_models/book-update.dto';
import { KeywordDto } from '../_models/keyword.dto';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http: HttpClient) { }

  addBook(model: AddBookDto) {
    return this.http.post<AddBookDto>('/api/admin/addbook', model);
  }

  getKeywords(bookId: number): Observable<KeywordDto[]> {
    return this.http.get<KeywordDto[]>(`api/admin/keywords/${bookId}`);
  }

  updateKeyword(keyword: KeywordDto) {
    return this.http.put('api/admin/keywords', keyword);
  }

  removeKeyword(keywordId: any) {
    return this.http.delete(`api/admin/keywords?keywordId=${keywordId}`);
  }

  getBook(bookId: number): Observable<BookUpdateDto> {
    return this.http.get<BookUpdateDto>(`api/admin/book/${bookId}`);
  }
}
