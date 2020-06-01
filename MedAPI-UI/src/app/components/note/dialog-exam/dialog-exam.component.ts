import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-exam',
  templateUrl: './dialog-exam.component.html',
  styleUrls: ['./dialog-exam.component.scss']
})
export class DialogExamComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<DialogExamComponent>,
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
}
