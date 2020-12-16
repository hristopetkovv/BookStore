import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { UserDto } from '../_models/user.dto';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  loggedIn: boolean = false;
  @Output() cancelRegister = new EventEmitter();

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  register() {
    this.authService.register(this.model)
      .subscribe((user: UserDto) => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.authService.setCurrentUser(user);
          this.loggedIn = true;
          this.authService.isLoggedIn(this.loggedIn);
        }
      }, error => {
        console.log(error);
      });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
