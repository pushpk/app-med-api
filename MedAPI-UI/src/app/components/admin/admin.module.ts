import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { FormsModule } from '@angular/forms';

import { AdminComponent } from './admin.component';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableFilterModule } from 'mat-table-filter';

const routes: Routes = [
  { path: '', component: AdminComponent,  pathMatch: 'full'}
  
];

@NgModule({ 
  declarations: [AdminComponent],
  imports: [
    CommonModule,
    FormsModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatTableFilterModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class AdminModule { }
