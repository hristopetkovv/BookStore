import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  constructor(private http: HttpClient) { }

  getNotFound() {
    return this.http.get('api/error/not-found');
  }

  getServerError() {
    return this.http.get('api/error/server-error');
  }

  getBadRequest() {
    return this.http.get('api/error/bad-request');
  }

  getNotAuthorized() {
    return this.http.get('api/error/auth');
  }

  getValidationError() {
    return this.http.post('api/account/register', {});
  }
}
