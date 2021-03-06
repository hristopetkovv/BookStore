import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserDto } from '../../_models/user.dto';
import { AuthService } from '../../_services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  loggedIn: boolean = false;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
  }

  login() {
    this.authService.login(this.model)
      .subscribe((user: UserDto) => {
        if (user) {
          this.authService.isUserInRole(user.role);
          localStorage.setItem('user', JSON.stringify(user));
          this.authService.setCurrentUser(user);
          this.loggedIn = true;
          this.authService.isLoggedIn(this.loggedIn);
          this.router.navigateByUrl('/book');
        }
      }, error => {
        console.log(error);
      });
  }
}
