import { CommonModule, TitleCasePipe } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatChipsModule } from '@angular/material/chips';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSliderModule } from '@angular/material/slider';
import { MatSortModule } from '@angular/material/sort';
import { MatStepperModule } from '@angular/material/stepper';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { ngfModule } from 'angular-file';
import { ToastrModule } from 'ngx-toastr';
import { NgInit } from './directive/nginit.directive';
import { HeaderComponent } from './header/header.component';
import { IdleLogoutComponent } from './idle-logout/idle-logout.component';
import { OrderByPipe } from './order-by.pipe';
import { SidenavComponent } from './sidenav/sidenav.component';
import { DialogTermsAndConditionsComponent } from './termsAndConditions/dialog-terms-and-conditions.component';

@NgModule({
  declarations: [
    HeaderComponent,
    SidenavComponent,
    NgInit,
    OrderByPipe,
    DialogTermsAndConditionsComponent,
    IdleLogoutComponent,
  ],
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
    MatTableModule,
    MatProgressSpinnerModule,
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
    }),
    ngfModule,
    MatGridListModule,
    MatDatepickerModule,
    MatMomentDateModule,
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
    MatMomentDateModule,
  ],
  providers: [MatDatepickerModule, MatNativeDateModule, TitleCasePipe],
})
export class SharedModule {}
