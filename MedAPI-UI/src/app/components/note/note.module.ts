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

const routes: Routes = [
  {
    path: '', component: NoteComponent
  }
];

@NgModule({
  declarations: [NoteComponent, FormTriageComponent, FormSymptomsComponent, FormSummaryComponent,
    DialogMedicineComponent, DialogExamComponent, DialogDiagnosisComponent, FormConclusionComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class NoteModule { }
