import {
  Component,
  OnInit,
  Input,
  EventEmitter,
  Output,
  ViewChild,
} from '@angular/core';
import { NoteService } from '../services/note.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { DialogBmiComponent } from '../indicators/dialog-bmi/dialog-bmi.component';
import { DialogCardiovascularAgeComponent } from '../indicators/dialog-cardiovascular-age/dialog-cardiovascular-age.component';
import { DialogCardiovascularRiskFraminghamComponent } from '../indicators/dialog-cardiovascular-risk-framingham/dialog-cardiovascular-risk-framingham.component';
import { DialogCardiovascularRiskReynoldsComponent } from '../indicators/dialog-cardiovascular-risk-reynolds/dialog-cardiovascular-risk-reynolds.component';
import { DialogHypertensionRiskComponent } from '../indicators/dialog-hypertension-risk/dialog-hypertension-risk.component';
import { DialogDiabetesRiskComponent } from '../indicators/dialog-diabetes-risk/dialog-diabetes-risk.component';
import { DialogFractureRiskComponent } from '../indicators/dialog-fracture-risk/dialog-fracture-risk.component';
import { FormCanDeactivate } from 'src/app/auth/form-can-deactivate';
import { ControlContainer, NgForm } from '@angular/forms';
// import { ConsoleReporter } from 'jasmine';

@Component({
  selector: 'app-form-triage',
  templateUrl: './form-triage.component.html',
  styleUrls: ['./form-triage.component.scss'],
  viewProviders: [{ provide: ControlContainer, useExisting: NgForm }],
})
export class FormTriageComponent implements OnInit {
  resources: any;
  @Input() note: any;
  @Input() patient: any;
  @Input() isEditable: boolean;
  @Output() computedFieldsChange = new EventEmitter<any>();
  isTeleconsultation = true;
  showSelectVitalFunctions = false;
  BMI: number;

  constructor(public noteService: NoteService, public dialog: MatDialog) {}

  ngOnInit(): void {
    if (!this.isEditable){
      this.isTeleconsultation = false;
    }
    this.noteService.resources.subscribe((o) => {
      this.resources = o;
    });
  }

  onSpecialtySelected(event): any{
    const specialty = this.resources.specialities.find(d => d.id.toString() === event.toString());
    if (specialty.name === 'CARDIOLOGIA' || specialty.name === 'MEDICINA GENERAL' || specialty.name === 'MEDICINA INTERNA' || specialty.name === 'NEUMOLOGIA'){
      this.showSelectVitalFunctions = true;
    }
    else {
      this.showSelectVitalFunctions = false;
    }
  }

  updateForm(event): any{
    this.noteService.setIsTeleconsultation(event.checked);
  }

  updateComputedFields() {
    this.computedFieldsChange.emit(this.note);
  }

  showIndicatorDialog(o: any) {
    const dialogConfig = new MatDialogConfig();
    let dialogModal: any;
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;

    if (o === 'bmi') {
      dialogModal = DialogBmiComponent;
    } else if (o === 'cardiovascularRiskFramingham') {
      dialogModal = DialogCardiovascularRiskFraminghamComponent;
    } else if (o === 'cardiovascularRiskReynolds') {
      dialogModal = DialogCardiovascularRiskReynoldsComponent;
    } else if (o === 'hypertensionRisk') {
      dialogModal = DialogHypertensionRiskComponent;
    } else if (o === 'diabetesRisk') {
      dialogModal = DialogDiabetesRiskComponent;
    } else if (o === 'fractureRisk') {
      dialogModal = DialogFractureRiskComponent;
    } else if (o === 'cardiovascularAge') {
      dialogModal = DialogCardiovascularAgeComponent;
    }

    const dialogRef = this.dialog.open(dialogModal, {
      panelClass: 'custom-dialog',
      data: {
        note: this.note,
        patient: this.patient,
      },
    });

    dialogRef
      .afterClosed()
      .subscribe((data) => console.log('Dialog output:', data));
  }
}
