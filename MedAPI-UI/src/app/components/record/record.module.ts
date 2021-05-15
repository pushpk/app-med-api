import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { RouterModule, Routes } from '@angular/router';
import { MatTableFilterModule } from 'mat-table-filter';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { SharedModule } from '../../shared/shared.module';
import { RecordComponent } from './record.component';

const routes: Routes = [
  { path: '', component: RecordComponent, pathMatch: 'full' },
  { path: ':id', component: RecordComponent },
  {
    path: 'notes',
    loadChildren: () => import('../note/note.module').then((m) => m.NoteModule),
  },
];

@NgModule({
  declarations: [RecordComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatTableFilterModule,
    RouterModule.forChild(routes),
    SharedModule,
    MatProgressSpinnerModule,
    NgMultiSelectDropDownModule.forRoot(),
  ],
})
export class RecordModule {}
