import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonService } from '../../services/common.service';
import { UserAuthService } from '../../auth/user-auth.service';
import { UserService } from '../../components/user/user.service';
import { BnNgIdleService } from 'bn-ng-idle';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(private router: Router,
    public commonService: CommonService,
    private userService: UserService,
    public userAuthService: UserAuthService,
    ) { }

  // ngOnDestroy(): void {
  //   this.loggedInSubscription.unsubscribe();
  // }

  ngOnInit(): void {
  }

  navigateToLogout() {
    //this.router.navigateByUrl('/logout');
  }

  toggleFilter() {
    this.commonService.slideEmitter.emit();
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
