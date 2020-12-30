import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-terms-and-conditions',
  templateUrl: './dialog-terms-and-conditions.component.html',
  styleUrls: ['./dialog-terms-and-conditions.component.scss']
})
export class DialogTermsAndConditionsComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<DialogTermsAndConditionsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
  }
  
  cancel(): void {
    this.dialogRef.close({
      accept: false,
    });
  }

  answer() {
    this.dialogRef.close({
      accept: true,
    });
  }

}
