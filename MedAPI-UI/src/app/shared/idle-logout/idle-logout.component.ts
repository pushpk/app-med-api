import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { UserAuthService } from 'src/app/auth/user-auth.service';
import { UserService } from 'src/app/components/user/user.service';

@Component({
  selector: 'app-idle-logout',
  templateUrl: './idle-logout.component.html',
  styleUrls: ['./idle-logout.component.scss']
})
export class IdleLogoutComponent implements OnInit, OnDestroy {
  timeLeft: number = 120;
  interval: any;

  constructor(public dialogRef: MatDialogRef<IdleLogoutComponent>,
    private userAuthService: UserAuthService, private router: Router,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnDestroy(): void {
    this.timeLeft = 120;
    this.interval = null;
  }

  ngOnInit(): void {
    this.startTimer();
  }

  logout(): void {
    this.dialogRef.close({
      logout: true,
    });
    this.userAuthService.clear();
    // this.userService.setInactivityAlert(true);
    // this.userService.resetTimer();
    // this.userService.stopTimer();
  }

  cancel() {
    this.dialogRef.close({
      logout: false,
    });
    // this.userService.setInactivityAlert(false);
    // this.userService.resetTimer();
    // this.userService.stopTimer();
  }

  startTimer() {
    this.interval = setInterval(() => {
      if(this.timeLeft > 0) {
        this.timeLeft--;
      } else {
        this.logout();
      }
    },1000)
  }

}
