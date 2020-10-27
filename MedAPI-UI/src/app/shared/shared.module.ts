import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatStepperModule } from '@angular/material/stepper';
import { MatDialogModule } from '@angular/material/dialog';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSliderModule } from '@angular/material/slider';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDividerModule } from '@angular/material/divider';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { SidenavComponent } from './sidenav/sidenav.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { NgInit } from './directive/nginit.directive';
import { MatChipsModule } from '@angular/material/chips';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import { ToastrModule } from 'ngx-toastr';
import { ngfModule } from 'angular-file';
import { MatGridListModule } from '@angular/material/grid-list';
import { OrderByPipe } from './order-by.pipe';

@NgModule({
  declarations: [HeaderComponent, SidenavComponent, NgInit, OrderByPipe],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatIconModule,
    MatMenuModule,
    MatSidenavModule,
    MatToolbarModule,
    FlexLayoutModule,
    MatProgressBarModule,
    MatAutocompleteModule,
    MatChipsModule,
    MatListModule,
    MatSlideToggleModule,
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
    }),
    ngfModule,
    MatGridListModule,
    MatDatepickerModule,
    MatMomentDateModule
  ],
  exports: [
    HeaderComponent,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatStepperModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatIconModule,
    MatAutocompleteModule,
    MatListModule,
    MatMenuModule,
    MatPaginatorModule,
    MatRadioModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    FlexLayoutModule,
    SidenavComponent,
    MatProgressBarModule,
    NgInit,
    MatChipsModule,
    MatSlideToggleModule,
    ToastrModule,
    ngfModule,
    MatGridListModule,
    OrderByPipe,
    MatDatepickerModule,
    MatNativeDateModule,
    MatMomentDateModule
  ],
  providers: [
    MatDatepickerModule,
    MatNativeDateModule
  ],
})
export class SharedModule { }
