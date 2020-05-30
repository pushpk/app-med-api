import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PatientComponent } from './patient.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { CreatePatientComponent } from './create-patient/create-patient.component';

const routes: Routes = [
  {
    path: '', component: PatientComponent,
    children: [
      { path: 'new', component: CreatePatientComponent}
    ]
  }
];


@NgModule({
  declarations: [PatientComponent, CreatePatientComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class PatientModule { }
