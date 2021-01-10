import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

enum DiagnosisType {
  IMAGE = 0,
  LABORATORY = 1,
}

@Component({
  selector: 'app-dialog-diagnosis',
  templateUrl: './dialog-diagnosis.component.html',
  styleUrls: ['./dialog-diagnosis.component.scss'],
})
export class DialogDiagnosisComponent implements OnInit {
  type: any;
  constructor(
    public dialogRef: MatDialogRef<DialogDiagnosisComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {}

  cancel(): void {
    this.dialogRef.close({
      accept: false,
    });
  }

  answer() {
    this.dialogRef.close({
      accept: true,
      type: this.type,
      note: this.data.note,
    });
  }
}
