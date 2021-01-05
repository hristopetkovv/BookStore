import { Component, OnInit } from '@angular/core';
import { UserDetailsDto } from '../_models/user-details.dto';
import { AuthService } from '../_services/auth.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  isLoggedIn: boolean;
  user: UserDetailsDto = new UserDetailsDto();

  constructor(private authService: AuthService, private userService: UserService) { }

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedInUser;
    this.getUser();
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }

  getUser() {
    this.userService.getUser().subscribe(user => console.log(user))
  }

}
