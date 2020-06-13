import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

enum ExamStatus {
  NOW = 0,
  DEFERRED = 1
}

@Component({
  selector: 'app-dialog-exam',
  templateUrl: './dialog-exam.component.html',
  styleUrls: ['./dialog-exam.component.scss']
})
export class DialogExamComponent implements OnInit {
  status: ExamStatus;
  text: string;
  files: File[] = [];
  maxSize: any;
  lastInvalids: any
  lastFileAt: Date;

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
    this.dialogRef.close({
      accept: true,
      text: this.text,
      files: this.files
    });
  }

  getDate() {
    return new Date();
  }
}
