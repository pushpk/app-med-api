import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NoteComponent } from './note.component';
import { FormTriageComponent } from './form-triage/form-triage.component';
import { FormSymptomsComponent } from './form-symptoms/form-symptoms.component';
import { FormSummaryComponent } from './form-summary/form-summary.component';
import { DialogMedicineComponent } from './dialog-medicine/dialog-medicine.component';
import { DialogExamComponent } from './dialog-exam/dialog-exam.component';
import { DialogDiagnosisComponent } from './dialog-diagnosis/dialog-diagnosis.component';
import { FormConclusionComponent } from './cardiology/form-conclusion/form-conclusion.component';
import { DialogBmiComponent } from './indicators/dialog-bmi/dialog-bmi.component';
import { DialogCardiovascularAgeComponent } from './indicators/dialog-cardiovascular-age/dialog-cardiovascular-age.component';
import { DialogCardiovascularRiskFraminghamComponent } from './indicators/dialog-cardiovascular-risk-framingham/dialog-cardiovascular-risk-framingham.component';
import { DialogCardiovascularRiskReynoldsComponent } from './indicators/dialog-cardiovascular-risk-reynolds/dialog-cardiovascular-risk-reynolds.component';
import { DialogDiabetesRiskComponent } from './indicators/dialog-diabetes-risk/dialog-diabetes-risk.component';
import { DialogFractureRiskComponent } from './indicators/dialog-fracture-risk/dialog-fracture-risk.component';
import { DialogHypertensionRiskComponent } from './indicators/dialog-hypertension-risk/dialog-hypertension-risk.component';
import { CardioFormSymptomsComponent } from './cardiology/cardio-form-symptoms/cardio-form-symptoms.component';

const routes: Routes = [
  {
    path: 'new', component: NoteComponent,
    children: [
      { path: ':speciality', component: NoteComponent }
    ]
  }
];

@NgModule({
  declarations: [NoteComponent, FormTriageComponent, FormSymptomsComponent, FormSummaryComponent,
    DialogMedicineComponent, DialogExamComponent, DialogDiagnosisComponent, FormConclusionComponent,
    DialogBmiComponent, DialogCardiovascularAgeComponent, DialogCardiovascularRiskFraminghamComponent,
    DialogCardiovascularRiskReynoldsComponent, DialogDiabetesRiskComponent, DialogFractureRiskComponent,
    DialogHypertensionRiskComponent,
    CardioFormSymptomsComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class NoteModule { }
