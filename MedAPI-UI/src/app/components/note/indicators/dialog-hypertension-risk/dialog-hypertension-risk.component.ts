import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-hypertension-risk',
  templateUrl: './dialog-hypertension-risk.component.html',
  styleUrls: ['./dialog-hypertension-risk.component.scss']
})
export class DialogHypertensionRiskComponent implements OnInit {
  public patient: any = {
    sex: 'M',
    cigarettes: 0,
    personalBackground: ['HIPERTENSION'],
    medicines: ['ANTIHIPERTENSIVOS'],
    age: 20,
    fatherBackground: ['HIPERTENSION'],
    motherBackground: ['HIPERTENSION'],
  }

  constructor(public dialogRef: MatDialogRef<DialogHypertensionRiskComponent>,
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
