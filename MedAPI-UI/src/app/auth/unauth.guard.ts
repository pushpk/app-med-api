import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { UserAuthService } from './user-auth.service';

@Injectable()
export class UnauthGuard implements CanActivate {

  constructor(private auth: UserAuthService, private router: Router) {
  }

  canActivate() {
      if (!this.auth.isAuthenticated()) {
      return true;
    }
    this.router.navigateByUrl('/main');
    return false;
  }
}
