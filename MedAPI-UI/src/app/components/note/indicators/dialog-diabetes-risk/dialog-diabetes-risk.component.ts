import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-diabetes-risk',
  templateUrl: './dialog-diabetes-risk.component.html',
  styleUrls: ['./dialog-diabetes-risk.component.scss']
})
export class DialogDiabetesRiskComponent implements OnInit {
  public patient: any = {
    sex: 'M',
    cigarettes: 0,
    personalBackground: ['HIPERTENSION'],
    medicines: ['ANTIHIPERTENSIVOS'],
    age: 20,
    fatherBackground: ['HIPERTENSION'],
    motherBackground: ['HIPERTENSION'],
    physicalActivity: 'MODERADA'
  }

  constructor(public dialogRef: MatDialogRef<DialogDiabetesRiskComponent>,
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
