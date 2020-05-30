import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-cardiovascular-risk-reynolds',
  templateUrl: './dialog-cardiovascular-risk-reynolds.component.html',
  styleUrls: ['./dialog-cardiovascular-risk-reynolds.component.scss']
})
export class DialogCardiovascularRiskReynoldsComponent implements OnInit {
  public patient: any = {
    sex: 'M',
    cigarettes: 0,
    personalBackground: ['DIABETES_MELITUS_'],
    medicines: ['ANTIHIPERTENSIVOS'],
    age: 20,
    fatherBackground: ['ENFERMEDAD_CARDIOVASCULAR'],
    motherBackground: ['ENFERMEDAD_CARDIOVASCULAR'],
  }
  constructor(public dialogRef: MatDialogRef<DialogCardiovascularRiskReynoldsComponent>,
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
