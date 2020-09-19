import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';
import { Routes, RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserService } from './user.service';
import { MedicRegistrationComponent } from './medic-registration/medic-registration.component';
import { MustMatchDirective } from 'src/app/shared/directive/mustMatch.directive';
import { PatientRegistrationComponent } from './patient-registration/patient-registration.component';
import { LabRegistrationComponent } from './lab-registration/lab-registration.component';

const routes: Routes = [
  {
    path: '', component: LoginComponent

  },
  {
    path: 'logout', component: LogoutComponent
  }
];


@NgModule({
  declarations: [LoginComponent, LogoutComponent, MedicRegistrationComponent, MustMatchDirective, PatientRegistrationComponent, LabRegistrationComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule
  ],
  providers: [UserService]

})
export class UserModule { }
