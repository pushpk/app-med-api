import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { FormsModule } from '@angular/forms';

import { AdminComponent } from './admin.component';

const routes: Routes = [
  { path: '', component: AdminComponent,  pathMatch: 'full'}
  
];

@NgModule({ 
  declarations: [AdminComponent],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class AdminModule { }
