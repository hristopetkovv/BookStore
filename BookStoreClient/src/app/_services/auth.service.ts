import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserDto } from '../_models/user.Dto';
import { Observable, ReplaySubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentUserSource = new ReplaySubject<UserDto | null>(1);
  currentUser = this.currentUserSource.asObservable();
  logedInSubject: Subject<boolean>;
  isLoggedInUser = false;

  constructor(private http: HttpClient) {
    this.logedInSubject = new Subject<boolean>();
  }

  login(model: any): Observable<UserDto> {
    return this.http.post<UserDto>('/api/Account/login', model);
  }

  register(model: any): Observable<UserDto> {
    return this.http.post<UserDto>('/api/Account/register', model);
  }

  setCurrentUser(user: UserDto) {
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }

  isLoggedIn(loggedIn: boolean): void {
    this.logedInSubject.next(loggedIn);
    this.isLoggedInUser = loggedIn;
  }

  logedInChange(): Observable<boolean> {
    return this.logedInSubject;
  }
}
