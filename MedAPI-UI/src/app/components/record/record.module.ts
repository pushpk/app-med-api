import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecordComponent } from './record.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { NoteComponent } from '../note/note.component';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

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
    RouterModule.forChild(routes),
    SharedModule,
    MatProgressSpinnerModule,
    NgMultiSelectDropDownModule.forRoot()
  ]
})
export class RecordModule { }
