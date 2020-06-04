import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { NoteService } from '../services/note.service';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';
import { DialogDiagnosisComponent } from '../dialog-diagnosis/dialog-diagnosis.component';
import { MatDialog } from '@angular/material/dialog';

export interface State {
  flag: string;
  name: string;
  population: string;
}

@Component({
  selector: 'app-form-symptoms',
  templateUrl: './form-symptoms.component.html',
  styleUrls: ['./form-symptoms.component.scss']
})
export class FormSymptomsComponent implements OnInit {
  resources: any;
  @Input() note: any;
  @Input() patient: any;
  diagnosisCtrl = new FormControl();
  examCtrl = new FormControl();
  treatmentCtrl = new FormControl();
  interconsultationCtrl = new FormControl();
  options: string[] = ['One', 'Two', 'Three'];
  tempTimeobj: any;
  filteredDiagnosis: Observable<[]>;
  showProgressBar = false;
  //@Output() diagnosisChange = new EventEmitter<any>();
  //@Output() diagnosisModalChange = new EventEmitter<any>();
  selectedDiagnosis: any;
  searchDiagnosis: string;
  constructor(public noteService: NoteService, public dialog: MatDialog) {
  }

  ngOnInit(): void {
    console.log(this.note, 'note');
    this.noteService.resources.subscribe((o) => {
      this.resources = o;
    });

    //this.noteService.diagnosisList.subscribe((o) => {
    //});
  }

  getDiagnosis() {
    let str = '';
    this.diagnosisCtrl.valueChanges.subscribe((value: string) => {
      str += value;
    });
    clearTimeout(this.tempTimeobj);
    this.tempTimeobj = setTimeout(() => {
      if (str.length >= 2) {
        //this.showProgressBar = true;
        //this.diagnosisChange.emit(str);
        this.noteService.queryDiagnosis(str).then(response => {
         this.note.diagnosis.list = response;
          console.log(response);
        });
      }
    }, 1000);
  }

  displayFn(data?: any): string | undefined {
    console.log(data, 'data');
    return data ? data.Title : undefined;
  }

  //openDignosisModal(data: any) {
  //  console.log(data, 'data');
  //  this.diagnosisModalChange.emit(data);
  //}

  addDiagnosis(diagnosis: any): void {
    console.log(diagnosis, 'diagnosis');
    if (!diagnosis) {
      return;
    }

    this.selectedDiagnosis = undefined;
    this.searchDiagnosis = '';
    let dialogRef = this.dialog.open(DialogDiagnosisComponent, {
      panelClass: 'custom-dialog',
      data: {
        note: this.note
      }
    });
    dialogRef.afterClosed().subscribe((response) => {

      if (response.accept && response.type) {
        diagnosis.type = response.type;
      } else {
        diagnosis.type = '';
      }

      const index = this.note.diagnosis.list.indexOf(diagnosis);
      if (index === -1) {
        this.note.diagnosis.list.push(diagnosis);
      }
      console.log("Dialog output:", response)
    });
  }

  removeDiagnosis(diagnosis: any): void {
    let index = this.note.diagnosis.list.indexOf(diagnosis);
    if (index !== -1) {
      this.note.diagnosis.list.splice(index, 1);
    }
  }
}
