import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthorDto } from '../_models/author.dto';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

  constructor(private http: HttpClient) { }

  getAuthors(sortOrder: string): Observable<AuthorDto[]> {
    const params = { sortOrder };

    return this.http.get<AuthorDto[]>('api/author', { params });
  }
}
