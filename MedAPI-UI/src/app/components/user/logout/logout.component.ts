import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserAuthService } from '../../../auth/user-auth.service';
import { UserService } from '../user.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.scss']
})
export class LogoutComponent implements OnInit {
  constructor(private router: Router, private userService: UserService,
    public userAuthService: UserAuthService) { }

  ngOnInit(): void {
  }

  logout() {
    const userAuth = this.userAuthService.load();
    if (userAuth == null) return;
    this.userService.logout().then(() => {
      this.userAuthService.clear();
      this.router.navigateByUrl('/login');
    }, (error) => {
      console.log(error);
      this.userAuthService.clear();
      this.router.navigateByUrl('/login');
    });
  }

}
