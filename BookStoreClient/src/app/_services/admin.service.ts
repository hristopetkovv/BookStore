import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddBookDto } from '../_models/add-book.dto';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http: HttpClient) { }

  addBook(model: AddBookDto) {
    return this.http.post<AddBookDto>('/api/admin/addbook', model);
  }
}
