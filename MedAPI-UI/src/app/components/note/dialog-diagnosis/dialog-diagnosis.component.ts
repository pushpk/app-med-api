import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-diagnosis',
  templateUrl: './dialog-diagnosis.component.html',
  styleUrls: ['./dialog-diagnosis.component.scss']
})
export class DialogDiagnosisComponent implements OnInit {
  type: any;
  constructor(public dialogRef: MatDialogRef<DialogDiagnosisComponent>,
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
