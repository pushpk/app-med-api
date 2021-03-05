import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { BnNgIdleService } from 'bn-ng-idle';
import { ToastrService } from 'ngx-toastr';
import { UserAuthService } from 'src/app/auth/user-auth.service';
import { IdleLogoutComponent } from 'src/app/shared/idle-logout/idle-logout.component';
import { HttpUtilService } from '../../services/http-util.service';
import { User } from './model/user.model';

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
    public dialog: MatDialog
  ) {}

  login(params: any) {
    const self = this;
    // const apiEndpoint = 'users/login';
    const apiEndpoint = 'token';
    return self.httpUtilService
      .login(params, apiEndpoint, null)
      .then(
        (response: {
          access_token: string;
          token_type: string;
          expires_in: string;
        }) => {
          localStorage.setItem('access_token', response.access_token);
          localStorage.setItem('token_type', response.token_type);
          localStorage.setItem('expires_in', response.expires_in);

          return self.httpUtilService
            .invokeQuery('GET', null, 'users/Get-User-Info')
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
                this.timer = this.bnIdle
                  .startWatching(1200)
                  .subscribe((isTimedOut: boolean) => {
                    // console.log(isTimedOut);
                    if (isTimedOut) {
                      this.showIdleTimer();
                    }
                  });
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
              this.toastr.error(
                'Incorrect email or password, Please try again!'
              );
              console.log(error);
              //}
            });
        }
      )
      .catch((error) => {
        // if (error['status'] === 401) {
        //   this.toastr.toastrConfig.extendedTimeOut = 0;
        //   this.toastr.toastrConfig.timeOut = 0;
        //   this.toastr.error(error.error);
        // } else {
        this.toastr.error('Incorrect email or password, Please try again!');
        console.log(error);
        //}
      });
  }

  loggedIn(): any {
    // return true if token is not expired.
    const email = localStorage.getItem('email');
    // console.log(token);
    if (email === null) {
      return false;
    }
    return true;
  }

  logout() {
    const self = this;

    if (this.timer) {
      this.bnIdle.stopTimer();
      this.timer.unsubscribe();
    }
  }

  showIdleTimer() {
    let dialogRef = this.dialog.open(IdleLogoutComponent, {
      panelClass: 'custom-dialog',
      data: {},
      autoFocus: false,
      maxWidth: '120vh',
    });
    dialogRef.afterClosed().subscribe((response: any) => {
      if (response !== undefined && response.logout === false) {
        this.showInactivityAlert = false;
        this.bnIdle.stopTimer();
        this.bnIdle.resetTimer();
      } else {
        this.bnIdle.stopTimer();
        this.timer.unsubscribe();
        this.showInactivityAlert = true;
        this.logout();
        this.userAuthService.clear();
        this.router.navigateByUrl('/login');
        console.log('session expired');
      }
    });
  }
}
