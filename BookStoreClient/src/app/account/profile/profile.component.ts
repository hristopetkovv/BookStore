import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserDetailsDto } from '../../_models/user-details.dto';
import { UserService } from '../../_services/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  user: UserDetailsDto = new UserDetailsDto();

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
    this.getUser();
  }

  getUser() {
    this.userService.getUser().subscribe(user => this.user = user);
  }

  update() {
    this.userService.updateUser(this.user).subscribe();
    this.router.navigateByUrl('/home');
  }

  cancel() {
    this.router.navigateByUrl('/')
  }
}
