import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-bmi',
  templateUrl: './dialog-bmi.component.html',
  styleUrls: ['./dialog-bmi.component.scss']
})
export class DialogBmiComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<DialogBmiComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    console.log(data, 'data');
  }

  ngOnInit(): void {
  }

  cancel(): void {
      this.dialogRef.close();
  }

  answer() {

  }
  updateComputedFields() {
  }
}
