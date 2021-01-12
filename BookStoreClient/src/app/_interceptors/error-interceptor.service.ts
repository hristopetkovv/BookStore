import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { EMPTY, Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptorService implements HttpInterceptor {

  constructor(private router: Router) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          if (error.status === 401) {
            this.router.navigate(['login']);
            return EMPTY;
          } else if (error.status === 404) {
            this.router.navigate(['not-found']);
            return EMPTY;
          } else if (error.status === 400) {
            this.router.navigate(['bad-request'])
            return EMPTY;
          } else if (error.status === 500) {
            this.router.navigate(['server-error']);
            return EMPTY;
          }

          return throwError(error);
        })
      )
  }
}
