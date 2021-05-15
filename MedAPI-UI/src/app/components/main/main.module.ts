import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main.component';
import { SidepanelComponent } from './sidepanel/sidepanel.component';
import { Routes, RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { AuthGuardService } from 'src/app/auth/auth-guard.service';

const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      {
        path: 'admin',
        loadChildren: () =>
          import('../admin/admin.module').then((m) => m.AdminModule),
        canActivate: [AuthGuardService],
      },
      {
        path: 'records',
        loadChildren: () =>
          import('../record/record.module').then((m) => m.RecordModule),
        canActivate: [AuthGuardService],
      },
      {
        path: 'patients',
        loadChildren: () =>
          import('../patient/patient.module').then((m) => m.PatientModule),
      },
    ],
  },
];

@NgModule({
  declarations: [MainComponent, SidepanelComponent],
  imports: [CommonModule, RouterModule.forChild(routes), SharedModule],
})
export class MainModule {}
