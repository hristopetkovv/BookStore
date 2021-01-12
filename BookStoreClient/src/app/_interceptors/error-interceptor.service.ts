import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptorService implements HttpInterceptor {

  constructor(private router: Router, private toastrService: ToastrService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          if (error) {
            switch (error.status) {
              case 400:
                if (error.error.errors) {
                  const modalStateErrors = [];
                  for (const key in error.error.errors) {
                    if (error.error.errors[key]) {
                      modalStateErrors.push(error.error.errors[key]);
                    }
                  }
                  throw modalStateErrors.map(e => e);
                } else {
                  this.toastrService.error(error.statusText, error.status.toString());
                }
                break;
              case 401:
                this.toastrService.error(error.statusText, error.status.toString());
                break;
              case 404:
                this.router.navigateByUrl('/not-found');
                break;
              case 500:
                // const navigationExtras: NavigationExtras = { state: { error: error.error } };
                this.toastrService.error(error.error.message)
                break;
              default:
                this.toastrService.error('Something unexpected went wrong.');
                console.log(error);
                break;
            }
          }

          return throwError(error);
        })
      )
  }
}
