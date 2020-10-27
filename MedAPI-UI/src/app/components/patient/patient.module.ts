import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PatientComponent } from './patient.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { CreatePatientComponent } from './create-patient/create-patient.component';
import { FormOneComponent } from './form-one/form-one.component';
import { FormTwoComponent } from './form-two/form-two.component';
import { FormThreeComponent } from './form-three/form-three.component';
import { FormFourComponent } from './form-four/form-four.component';
import { FormSummaryComponent } from './form-summary/form-summary.component';

const routes: Routes = [
  {
    path: '', component: PatientComponent,
    children: [
      { path: ':id', component: CreatePatientComponent}
    ]
  }
];


@NgModule({
  declarations: [PatientComponent, CreatePatientComponent,
    FormOneComponent, FormTwoComponent, FormThreeComponent,
    FormFourComponent, FormSummaryComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class PatientModule { }
