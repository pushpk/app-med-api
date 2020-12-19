import { Injectable } from '@angular/core';
import { User } from './model/user.model';
import { HttpUtilService } from '../../services/http-util.service';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { BnNgIdleService } from 'bn-ng-idle';
import { Router } from '@angular/router';
import { UserAuthService } from 'src/app/auth/user-auth.service';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  user: User;
  isLoggedIn = false;
  timer: any;
  showInactivityAlert = false;

  constructor(
    private httpUtilService: HttpUtilService,
    private toastr: ToastrService,
    private bnIdle: BnNgIdleService,
    private router: Router,
    public userAuthService: UserAuthService,
  ) {}

  login(params: any) {
    const self = this;
    const apiEndpoint = 'users/login';
    return self.httpUtilService
      .invoke('POST', params, apiEndpoint, null)
      .then(
        (response: {
          id: string;
          name: string;
          role: number;
          docNumber: string;
          permissions: string[];
          IsApproved: boolean;
          IsFreezed: boolean;
          message: string;
        }) => {
          this.timer = this.bnIdle.startWatching(900).subscribe((isTimedOut:boolean) => {
            // console.log(isTimedOut);
            if(isTimedOut) {
                this.showInactivityAlert = true;
                this.logout();
                this.userAuthService.clear();
                this.router.navigateByUrl('/login');
                console.log("session expired");
                this.bnIdle.resetTimer();
                this.timer.unsubscribe();
            }
          })
          if (response.message) {
            return response.message;
          } else {
            // console.log(response);
            self.user = new User(
              response.id,
              response.name,
              response.role,
              response.docNumber,
              response.permissions,
              response.IsApproved,
              response.IsFreezed
            );
            return self.user;
          }
        }
      )
      .catch((error) => {
        // if (error['status'] === 401) {
        //   this.toastr.toastrConfig.extendedTimeOut = 0;
        //   this.toastr.toastrConfig.timeOut = 0;
        //   this.toastr.error(error.error);
        // } else {
        this.toastr.error(error.error);
        //}
      });
  }

  loggedIn(): any{
    // return true if token is not expired.
    const email = localStorage.getItem('email');
    // console.log(token);
    if (email === null){
      return false;
    }
    return true;
  }

  logout() {
    const self = this;
    const apiEndpoint = 'logout';
    if (this.timer){
      this.bnIdle.resetTimer();
      this.timer.unsubscribe();
    }

    return self.httpUtilService
      .invoke('POST', null, apiEndpoint, null)
      .then((response) => {
        return response;
      });
  }


}
