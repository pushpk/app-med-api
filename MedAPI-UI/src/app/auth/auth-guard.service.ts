import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { UserAuthService } from './user-auth.service';
@Injectable({
  providedIn: 'root',
})
export class AuthGuardService implements CanActivate {
  public keyName: string = environment.userInfo_LocalStoreKey;

  constructor(public userAuthService: UserAuthService, public router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

    if (this.userAuthService.isAuthenticated() && route.data.role == undefined) {
      // logged in so return true
      return true;
    }
    else if (this.userAuthService.isAuthenticated() && route.data.role == 'admin' && this.load().siteAdmin) {
      return true;
    }

    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
    return false;
  }

  public header() {
    let header = new HttpHeaders({ 'content-type': 'application/json' });
    //header = header.append('content-language', this.LANGUAGE);
    //header = header.append('Authorization', 'Bearer ' + this.auth.load().token);
    return { headers: header };
  }

  public headerFormData() {
    return {
      headers: new HttpHeaders({ 'content-type': 'application/json' })
    }
  }

  public load() {
    try {
      let storedData: string = localStorage.getItem(this.keyName);
      if (!storedData) { throw Error('no user data found'); }
      return JSON.parse(storedData);
    } catch (e) { }
    return null;
  }
}
