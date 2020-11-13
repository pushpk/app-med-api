import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecordComponent } from './record.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { NoteComponent } from '../note/note.component';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
<<<<<<< HEAD
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
=======
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import {  MatTableFilterModule } from 'mat-table-filter';
import {  MatPaginatorModule } from '@angular/material/paginator';


>>>>>>> c5ac6eeeb537ea2dd53ebbdc1a807760b2ebbcd3

const routes: Routes = [
  { path: '', component: RecordComponent,  pathMatch: 'full'},
  { path: ':id', component: RecordComponent },
  { path: 'notes', loadChildren: () => import('../note/note.module').then(m => m.NoteModule) }
];

@NgModule({ 
  declarations: [RecordComponent],
  imports: [
    CommonModule,
    FormsModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatTableFilterModule,
    RouterModule.forChild(routes),
    SharedModule,
    MatProgressSpinnerModule,
    NgMultiSelectDropDownModule.forRoot()
  ]
})
export class RecordModule { }
