import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
// import { IConfig } from 'ngx-mask';
import { InputMaskDirective } from '../../shared/directive/input-mask.directive';
import { SharedModule } from '../../shared/shared.module';
import { CreatePatientComponent } from './create-patient/create-patient.component';
import { FormFourComponent } from './form-four/form-four.component';
import { FormOneComponent } from './form-one/form-one.component';
import { FormSummaryComponent } from './form-summary/form-summary.component';
import { FormThreeComponent } from './form-three/form-three.component';
import { FormTwoComponent } from './form-two/form-two.component';
import { PatientComponent } from './patient.component';

// export const options: Partial<IConfig> | (() => Partial<IConfig>) = null;

const routes: Routes = [
  {
    path: '',
    component: PatientComponent,
    children: [{ path: ':id', component: CreatePatientComponent }],
  },
];

@NgModule({
  declarations: [
    PatientComponent,
    CreatePatientComponent,
    FormOneComponent,
    FormTwoComponent,
    FormThreeComponent,
    FormFourComponent,
    FormSummaryComponent,
    InputMaskDirective,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes),

    SharedModule,
  ],
  exports: [InputMaskDirective],
})
export class PatientModule {}
