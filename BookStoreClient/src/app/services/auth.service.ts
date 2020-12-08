import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
private loginPath = environment.apiUrl + 'Account/login';
private registerPath = environment.apiUrl + 'Account/register';
  constructor(private http: HttpClient) {

   }

   login(data: any): Observable<any> {
     return this.http.post(this.loginPath, data);
   }

   register(data: any): Observable<any> {
     return this.http.post(this.registerPath, data);
   }
}
