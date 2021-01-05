import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserDetailsDto } from '../_models/user-details.dto';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getUser(): Observable<UserDetailsDto> {
    return this.http.get<UserDetailsDto>('api/home');
  }

  updateUser(model: any) {
    return this.http.put('api/home', model);
  }
}
