import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-medicine',
  templateUrl: './dialog-medicine.component.html',
  styleUrls: ['./dialog-medicine.component.scss']
})
export class DialogMedicineComponent implements OnInit {
  indications: string;
  constructor(public dialogRef: MatDialogRef<DialogMedicineComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
  }

  cancel(): void {
    this.dialogRef.close();
  }

  answer() {
    this.dialogRef.close({
      accept: true,
      indications: this.indications
    });
  }
}
