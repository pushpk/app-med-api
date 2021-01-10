import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-idle-logout',
  templateUrl: './idle-logout.component.html',
  styleUrls: ['./idle-logout.component.scss']
})
export class IdleLogoutComponent implements OnInit, OnDestroy {
  timeLeft: number = 120;
  interval: any;

  constructor(public dialogRef: MatDialogRef<IdleLogoutComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnDestroy(): void {
    this.timeLeft = 120;
    this.interval = null;
  }

  ngOnInit(): void {
    this.startTimer();
  }

  cancel(): void {
    this.dialogRef.close({
      logout: true,
    });
  }

  answer() {
    this.dialogRef.close({
      logout: false,
    });
  }

  startTimer() {
    this.interval = setInterval(() => {
      if(this.timeLeft > 0) {
        this.timeLeft--;
      } else {
        this.cancel();
      }
    },1000)
  }

}
