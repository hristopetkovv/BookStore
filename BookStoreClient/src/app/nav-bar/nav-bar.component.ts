import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  loggedIn: boolean = false;

  constructor(public authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.loggedIn = this.authService.isLoggedInUser;

    this.authService.logedInChange()
      .subscribe(isLoggedIn => this.loggedIn = isLoggedIn);
  }

  logout() {
    this.authService.logout();
    this.loggedIn = false;
    this.router.navigateByUrl('/login');
  }
}
