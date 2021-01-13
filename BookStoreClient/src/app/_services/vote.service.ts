import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VoteService {

  constructor(private http: HttpClient) { }

  vote(bookId: number, isUpVote: boolean): Observable<any> {
    return this.http.post('api/Vote', { bookId: bookId, isUpVote: isUpVote });
  }
}
