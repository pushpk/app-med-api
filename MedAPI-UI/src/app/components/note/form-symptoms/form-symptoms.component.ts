import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { NoteService } from '../services/note.service';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';
import { DialogDiagnosisComponent } from '../dialog-diagnosis/dialog-diagnosis.component';
import { MatDialog } from '@angular/material/dialog';
import { DialogExamComponent } from '../dialog-exam/dialog-exam.component';
import { DialogMedicineComponent } from '../dialog-medicine/dialog-medicine.component';
import { CheckEmptyUtil } from '../../../shared/util/check-empty.util';

@Component({
  selector: 'app-form-symptoms',
  templateUrl: './form-symptoms.component.html',
  styleUrls: ['./form-symptoms.component.scss']
})
export class FormSymptomsComponent implements OnInit {
  resources: any;
  @Input() note: any;
  @Input() patient: any;
  @Input() isEditable: boolean;
  
  //diagnosisCtrl = new FormControl();
  //examCtrl = new FormControl();
  //treatmentCtrl = new FormControl();
  //interconsultationCtrl = new FormControl();
  //tempTimeobj: any;
  //filteredDiagnosis: Observable<[]>;
  //showDignosisProgressBar = false;
  //showExamProgressBar = false;
  //showTreatmentProgressBar = false;
  //showInterconsultantionProgressBar = false;
  //@Output() diagnosisChange = new EventEmitter<any>();
  //@Output() diagnosisModalChange = new EventEmitter<any>();
  //selectedDiagnosis: any;
  //searchDiagnosis: string;
  //diagnosisList: [];
  //physicalExamsList: [];
  //treatmentList: [];
  //interconsultationList: [];

  //selectedExam: any;
  //searchExam = '';

  //selectedTreatment: any;
  //searchTreatment = '';

  //selectedSpecialty: any;
  //searchSpecialty = '';

  constructor(public noteService: NoteService, public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.noteService.resources.subscribe((o) => {
      this.resources = o;
      if (this.resources.durationUnits === undefined) {
        this.resources.durationUnits = [{ id: 1, name: 'Horas' },
        { id: 2, name: 'Dias' },
        { id: 3, name: 'Semanas' },
        { id: 4, name: 'Meses' },
        { id: 5, name: 'Años' }
        ];
      }
    });

    // console.log(this.note);
  }

  //getDiagnosis() {
  //  let str = '';
  //  this.diagnosisCtrl.valueChanges.subscribe((value: string) => {
  //    str += value;
  //  });
  //  clearTimeout(this.tempTimeobj);
  //  this.tempTimeobj = setTimeout(() => {
  //    if (str.length >= 2) {
  //      this.showDignosisProgressBar = true;
  //      //this.diagnosisChange.emit(str);
  //      this.noteService.queryDiagnosis(str).then(response => {
  //        this.showDignosisProgressBar = false;
  //        this.diagnosisList = response;
  //        console.log(response);
  //      });
  //    }
  //  }, 1000);
  //}

  //displayFn(data?: any): string | undefined {
  //  console.log(data, 'data');
  //  return data ? '' : undefined;
  //}

  //openDignosisModal(data: any) {
  //  console.log(data, 'data');
  //  this.diagnosisModalChange.emit(data);
  //}

  //addDiagnosis(diagnosis: any): void {
  //  console.log(diagnosis, 'diagnosis');
  //  if (!diagnosis) {
  //    return;
  //  }

  //  this.selectedDiagnosis = undefined;
  //  this.searchDiagnosis = '';
  //  let dialogRef = this.dialog.open(DialogDiagnosisComponent, {
  //    panelClass: 'custom-dialog',
  //    data: {
  //      note: this.note
  //    }
  //  });
  //  dialogRef.afterClosed().subscribe((response) => {

  //    if (response.accept && response.type) {
  //      diagnosis.type = response.type;
  //    } else {
  //      diagnosis.type = '';
  //    }

  //    const index = this.note.diagnosis.list.indexOf(diagnosis);
  //    if (index === -1) {
  //      this.note.diagnosis.list.push(diagnosis);
  //    }
  //    console.log(this.note.diagnosis.list, 'this.note.diagnosis.list');
  //    console.log("Dialog output:", response)
  //  });
  //}

  //removeDiagnosis(diagnosis: any): void {
  //  let index = this.note.diagnosis.list.indexOf(diagnosis);
  //  if (index !== -1) {
  //    this.note.diagnosis.list.splice(index, 1);
  //  }
  //}

  //getExams() {
  //  let str = '';
  //  this.examCtrl.valueChanges.subscribe((value: string) => {
  //    str += value;
  //  });
  //  clearTimeout(this.tempTimeobj);
  //  this.tempTimeobj = setTimeout(() => {
  //    if (str.length >= 2) {
  //      this.showExamProgressBar = true;
  //      this.noteService.queryExams(str).then(response => {
  //        this.showExamProgressBar = false;
  //        this.physicalExamsList = response;
  //        console.log(response);
  //      });
  //    }
  //  }, 1000);
  //}

  //addExams(exam: any) {
  //  if (!exam) {
  //    return;
  //  }

  //  var index = this.note.exams.list.indexOf(exam);
  //  if (index === -1) {
  //    this.note.exams.list.push(exam);
  //  }

  //  this.selectedExam = undefined;
  //  this.searchExam = '';
  //}

  //removeExam(exam: any) {
  //  let index = this.note.exams.list.indexOf(exam);
  //  if (index !== -1) {
  //    this.note.exams.list.splice(index, 1);
  //  }
  //}

  //showExamDialog(exam: any) {
  //  console.log(exam, 'exam');
  //  let dialogRef = this.dialog.open(DialogExamComponent, {
  //    panelClass: 'custom-dialog',
  //    data: {
  //      note: this.note
  //    }
  //  });
  //  dialogRef.afterClosed().subscribe((response) => {
  //    console.log("Dialog output:", response)
  //  });
  //}

  //getTreatments() {
  //  let str = '';
  //  this.treatmentCtrl.valueChanges.subscribe((value: string) => {
  //    str += value;
  //  });
  //  clearTimeout(this.tempTimeobj);
  //  this.tempTimeobj = setTimeout(() => {
  //    if (str.length >= 2) {
  //      this.showTreatmentProgressBar = true;
  //      this.noteService.queryTreatments(str).then(response => {
  //        this.showTreatmentProgressBar = false;
  //        this.treatmentList = response;
  //        console.log(response);
  //      });
  //    }
  //  }, 1000);
  //}


  //addTreatment(d) {
  //  console.log(d, 'd');
  //  if (!d) {
  //    return;
  //  }

  //  let dialogRef = this.dialog.open(DialogMedicineComponent, {
  //    panelClass: 'custom-dialog',
  //    data: {
  //      note: this.note
  //    }
  //  });
  //  dialogRef.afterClosed().subscribe((response) => {
  //    if (response.accept && response.indications) {
  //      d.indications = response.indications;
  //    } else {
  //      d.indications = '';
  //    }

  //    const index = this.note.treatments.list.indexOf(d);
  //    if (index === -1) {
  //      this.note.treatments.list.push(d);
  //    }      
  //    console.log("Dialog output:", response)
  //  });

  //  this.selectedTreatment = undefined;
  //  this.searchTreatment = '';
  //}

  //removeTreatment(d) {
  //  let index = this.note.treatments.list.indexOf(d);
  //  if (index !== -1) {
  //    this.note.treatments.list.splice(index, 1);
  //  }
  //}

  //getInterconsultations() {
  //  let str = '';
  //  this.interconsultationCtrl.valueChanges.subscribe((value: string) => {
  //    str += value;
  //  });
  //  clearTimeout(this.tempTimeobj);
  //  this.tempTimeobj = setTimeout(() => {
  //    if (str.length >= 2) {
  //      this.showInterconsultantionProgressBar = true;
  //      this.noteService.queryInterconsultations(str).then(response => {
  //        this.showInterconsultantionProgressBar = false;
  //        this.interconsultationList = response;
  //        console.log(response);
  //      });
  //    }
  //  }, 1000);
  //}

  //addSpecialty(d) {
  //  if (!d) {
  //    return;
  //  }
  //  let index = this.note.referrals.list.indexOf(d);
  //  if (index === -1) {
  //    this.note.referrals.list.push(d);
  //  }
  //  this.selectedSpecialty = undefined;
  //  this.searchSpecialty = '';
  //}

  //removeSpecialty(d) {
  //  var index = this.note.referrals.list.indexOf(d);
  //  if (index !== -1) {
  //    this.note.referrals.list.splice(index, 1);
  //  }
  //}

}
