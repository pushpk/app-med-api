import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from './auth/auth-guard.service';
import { AuthModule } from './auth/auth.module';
import { AccountConfirmationComponent } from './components/user/account-confirmation/account-confirmation.component';
import { AccountSettingComponent } from './components/user/account-setting/account-setting.component';
import { EmailNotConfirmedComponent } from './components/user/email-not-confirmed/email-not-confirmed.component';
import { ForgotPasswordComponent } from './components/user/forgot-password/forgot-password.component';
import { LabRegistrationComponent } from './components/user/lab-registration/lab-registration.component';
import { MedicRegistrationComponent } from './components/user/medic-registration/medic-registration.component';
import { NoAccessComponent } from './components/user/no-access/no-access.component';
import { PatientRegistrationComponent } from './components/user/patient-registration/patient-registration.component';
import { ResetPasswordComponent } from './components/user/reset-password/reset-password.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  {
    path: '',
    loadChildren: () =>
      import('../app/components/main/main.module').then((m) => m.MainModule),
  },
  {
    path: 'login',
    loadChildren: () =>
      import('../app/components/user/user.module').then((m) => m.UserModule),
  },
  { path: 'register', component: MedicRegistrationComponent },
  { path: 'patient-register', component: PatientRegistrationComponent },
  { path: 'lab-register', component: LabRegistrationComponent },
  { path: 'account-confirm', component: AccountConfirmationComponent },
  { path: 'forgot-password', component: ForgotPasswordComponent },
  { path: 'reset-password', component: ResetPasswordComponent },
  { path: 'email-not-confirmed', component: EmailNotConfirmedComponent },
  {
    path: 'account-setting',
    component: AccountSettingComponent,
    canActivate: [AuthGuardService],
  },
  { path: 'no-access', component: NoAccessComponent },
  //{ path: '**', redirectTo: 'login', data: { isRedirect: true } }
];

@NgModule({
  imports: [RouterModule.forRoot(routes), AuthModule],
  exports: [RouterModule],
})
export class AppRoutingModule {}
