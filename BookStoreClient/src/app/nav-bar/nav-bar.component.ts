import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  loggedIn: boolean = false;
  constructor(private authService: AuthService) { }
  
  ngOnInit(): void {
    this.authService.exportLoggedIn().subscribe(isLoggedIn => {
      if (isLoggedIn) {
        this.loggedIn = true;
      }
      else {
        this.loggedIn = false;
      }
    })
  }

  logout() {
    this.authService.logout();
    this.loggedIn = false;
  }
}
