import { Component, OnInit, Input, EventEmitter, Output, } from '@angular/core';
import { NoteService } from '../services/note.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { DialogBmiComponent } from '../indicators/dialog-bmi/dialog-bmi.component';
import { DialogCardiovascularAgeComponent } from '../indicators/dialog-cardiovascular-age/dialog-cardiovascular-age.component';
import { DialogCardiovascularRiskFraminghamComponent } from '../indicators/dialog-cardiovascular-risk-framingham/dialog-cardiovascular-risk-framingham.component';
import { DialogCardiovascularRiskReynoldsComponent } from '../indicators/dialog-cardiovascular-risk-reynolds/dialog-cardiovascular-risk-reynolds.component';
import { DialogHypertensionRiskComponent } from '../indicators/dialog-hypertension-risk/dialog-hypertension-risk.component';
import { DialogDiabetesRiskComponent } from '../indicators/dialog-diabetes-risk/dialog-diabetes-risk.component';
import { DialogFractureRiskComponent } from '../indicators/dialog-fracture-risk/dialog-fracture-risk.component';

@Component({
  selector: 'app-form-triage',
  templateUrl: './form-triage.component.html',
  styleUrls: ['./form-triage.component.scss']
})
export class FormTriageComponent implements OnInit {
  resources: any;
  @Input() note: any;
  @Input() patient: any;
  @Output() computedFieldsChange = new EventEmitter<any>();
  showInterconsultantionProgressBarTriage = false;
  tempTimeobjTriage: any;
  interconsultationListTriage: [];
  selectedSpecialty: any;
  searchSpecialty: string;


  constructor(public noteService: NoteService, public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.noteService.resources.subscribe((o) => {
      this.resources = o;
    });
  }

  updateComputedFields() {
    this.computedFieldsChange.emit(this.note);
  }

  getInterconsultations(termEntered:string) {
    console.log(termEntered);
    let str = termEntered;
    // this.interconsultationCtrl.valueChanges.subscribe((value: string) => {
    //   str += value;
    // });
    clearTimeout(this.tempTimeobjTriage);
    this.tempTimeobjTriage = setTimeout(() => {
      if (str.length >= 2) {
        this.showInterconsultantionProgressBarTriage = true;
        this.noteService.queryInterconsultations(str).then((response: any) => {
          this.showInterconsultantionProgressBarTriage = false;
          this.interconsultationListTriage = response;
        });
      }
    }, 1000);
  }

  addSpecialty(d) {
    if (!d) {
      return;
    }
    let index = this.note.referrals.list.indexOf(d);
    if (index === -1) {
      this.note.referrals.list.push({ name: d });
    }
    this.selectedSpecialty = undefined;
    this.searchSpecialty = '';
  }

  removeSpecialty(d) {
    var index = this.note.referrals.list.indexOf(d);
    if (index !== -1) {
      this.note.referrals.list.splice(index, 1);
    }
  }


  showIndicatorDialog(o: any) {
    console.log(o, 'o');
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
        patient: this.patient
      }
    });

    dialogRef.afterClosed().subscribe(
      data => console.log("Dialog output:", data)
    );
  }
}
