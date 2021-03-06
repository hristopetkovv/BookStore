import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserDto } from '../_models/user.dto';
import { Observable, ReplaySubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentUserSource = new ReplaySubject<UserDto | null>(1);
  currentUser = this.currentUserSource.asObservable();
  logedInSubject: Subject<boolean>;
  isLoggedInUser = false;
  isAdmin: boolean;

  constructor(private http: HttpClient) {
    this.logedInSubject = new Subject<boolean>();
    this.isLoggedInUser = localStorage.getItem('user') !== null && localStorage.getItem('user') !== undefined;
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

  getUsername(): string {
    if (!this.isLoggedInUser) {
      return null;
    }

    const user = JSON.parse(localStorage.getItem('user')) as UserDto;
    return user.username;
  }

  logout() {
    localStorage.removeItem('user');
    this.isLoggedInUser = false;
    this.currentUserSource.next(null);
  }

  isLoggedIn(loggedIn: boolean): void {
    this.isLoggedInUser = loggedIn;
    this.logedInSubject.next(loggedIn);
  }

  logedInChange(): Observable<boolean> {
    return this.logedInSubject;
  }

  getToken(): string {
    if (this.isLoggedInUser) {
      const user = JSON.parse(localStorage.getItem('user')) as UserDto;
      const token = user.token;

      return token;
    }

    return null;
  }

  isUserInRole(role: string) {
    if (role === "Admin") {
      this.isAdmin = true;
    } else if (role === "User") {
      this.isAdmin = false;
    }
  }
}
