import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormControl, NgForm } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { DialogDiagnosisComponent } from '../../dialog-diagnosis/dialog-diagnosis.component';
import { DialogExamComponent } from '../../dialog-exam/dialog-exam.component';
import { DialogMedicineComponent } from '../../dialog-medicine/dialog-medicine.component';
import { NoteService } from '../../services/note.service';

@Component({
  selector: 'app-form-conclusion',
  templateUrl: './form-conclusion.component.html',
  styleUrls: ['./form-conclusion.component.scss'],
  viewProviders: [{ provide: ControlContainer, useExisting: NgForm }],
})
export class FormConclusionComponent implements OnInit {
  resources: any;
  @Input() note: any;
  @Input() patient: any;
  @Input() isEditable: boolean;

  diagnosisCtrl = new FormControl();
  examCtrl = new FormControl();
  treatmentCtrl = new FormControl();
  interconsultationCtrl = new FormControl();
  tempTimeobj: any;

  showDignosisProgressBar = false;
  showExamProgressBar = false;
  showTreatmentProgressBar = false;
  showInterconsultantionProgressBar = false;
  isPharmacological = true;

  selectedDiagnosis: any;
  searchDiagnosis: string;
  diagnosisList: [];
  physicalExamsList: [];
  treatmentList: [];
  interconsultationList: [];

  selectedExam: any;
  searchExam = '';

  selectedTreatment: any;
  searchTreatment = '';

  selectedSpecialty: any;
  searchSpecialty = '';
  constructor(public noteService: NoteService, public dialog: MatDialog) {}

  ngOnInit(): void {
    this.noteService.resources.subscribe((o) => {
      this.resources = o;
      if (this.resources.durationUnits === undefined) {
        this.resources.durationUnits = [
          { id: 1, name: 'Horas' },
          { id: 2, name: 'Dias' },
          { id: 3, name: 'Semanas' },
          { id: 4, name: 'Meses' },
          { id: 5, name: 'Años' },
        ];
      }
      //this.filteredDiagnosis = this.diagnosisCtrl.valueChanges.pipe(
      //  startWith(null),
      //  map((data: string | null) => data ? this._filter(data) : this.resources.cardiovascularSymptom.slice()));
    });
    // console.log(this.note, 'note');
  }

  //private _filter(value: any): string[] {
  //  const filterValue = value.name.toLowerCase();
  //  return this.resources.cardiovascularSymptom.filter(x => x.name.toLowerCase().indexOf(filterValue) === 0);
  //}

  changeIsPharmacological(isPharmacological: boolean): any {
    // this.isPharmacological = !this.isPharmacological;
    this.noteService.setIsPharmacological(isPharmacological);
  }

  getDiagnosis(valueEntered: string) {
    let str = valueEntered;
    // this.diagnosisCtrl.valueChanges.subscribe((value: string) => {
    //   str += value;
    // });
    clearTimeout(this.tempTimeobj);
    this.tempTimeobj = setTimeout(() => {
      if (str.length >= 3) {
        this.showDignosisProgressBar = true;
        //this.diagnosisChange.emit(str);
        this.noteService.queryDiagnosis(str).then((response) => {
          this.showDignosisProgressBar = false;
          this.diagnosisList = response;
        });
      }
    }, 1000);
  }

  displayFn(data?: any): string | undefined {
    return data ? '' : undefined;
  }

  addDiagnosis(diagnosis: any): void {
    if (!diagnosis || !this.isEditable) {
      return;
    }

    this.selectedDiagnosis = undefined;
    this.searchDiagnosis = '';
    let dialogRef = this.dialog.open(DialogDiagnosisComponent, {
      panelClass: 'custom-dialog',
      data: {
        note: this.note,
      },
      autoFocus: false,
      maxWidth: '120vh',
    });
    dialogRef.afterClosed().subscribe((response: any) => {
      if (response.accept && response.type) {
        diagnosis.type = response.type;
        const index = this.note.diagnosis.list.indexOf(diagnosis);
        if (index === -1) {
          diagnosis.$id = Date.now();
          this.note.diagnosis.list.push(diagnosis);
        }
      } else {
        diagnosis.type = '';
      }
      this.diagnosisList = [];

      // console.log(this.note.diagnosis.list, 'this.note.diagnosis.list');
      // console.log("Dialog output:", response);
      // this.diagnosisInput.();
      // this.diagnosisInput.nativeElement.setAttribute('aria-haspopup', false);

      // console.log(this.diagnosisInput.nativeElement);
    });
  }

  removeDiagnosis(diagnosis: any): void {
    if (!this.isEditable) {
      return;
    }
    let index = this.note.diagnosis.list.indexOf(diagnosis);
    if (index !== -1) {
      this.note.diagnosis.list.splice(index, 1);
    }
  }

  getExams(termEntered: string) {
    let str = termEntered;
    // this.examCtrl.valueChanges.subscribe((value: string) => {
    //   str += value;
    // });

    clearTimeout(this.tempTimeobj);
    this.tempTimeobj = setTimeout(() => {
      if (str.length >= 2) {
        this.showExamProgressBar = true;
        this.noteService.queryExams(str).then((response) => {
          this.showExamProgressBar = false;
          this.physicalExamsList = response;
        });
      }
    }, 1000);
  }

  addExams(exam: any) {
    if (!exam || !this.isEditable) {
      return;
    }

    var index = this.note.exams.list.indexOf(exam);
    if (index === -1) {
      exam.$id = Date.now();
      this.note.exams.list.push(exam);
    }

    this.selectedExam = undefined;
    this.searchExam = '';
  }

  removeExam(exam: any) {
    if (!this.isEditable) {
      return;
    }
    let index = this.note.exams.list.indexOf(exam);
    if (index !== -1) {
      this.note.exams.list.splice(index, 1);
    }
  }

  showExamDialog(exam: any) {
    if (!this.isEditable) {
      return;
    }
    let dialogRef = this.dialog.open(DialogExamComponent, {
      panelClass: 'custom-dialog',
      data: {
        note: this.note,
      },
      autoFocus: false,
      maxWidth: '120vh',
    });
    dialogRef.afterClosed().subscribe((response) => {
      //  console.log("Dialog output:", response)
    });
  }

  getTreatments(termEntered: string) {
    let str = termEntered;

    clearTimeout(this.tempTimeobj);
    this.tempTimeobj = setTimeout(() => {
      if (str.length >= 3) {
        this.showTreatmentProgressBar = true;
        this.noteService.queryTreatments(str).then((response: any) => {
          this.showTreatmentProgressBar = false;
          this.treatmentList = response;
          //// console.log(response);
        });
      }
    }, 1000);
  }

  addTreatment(d) {
    if (!d || !this.isEditable) {
      return;
    }

    let dialogRef = this.dialog.open(DialogMedicineComponent, {
      panelClass: 'custom-dialog',
      data: {
        note: this.note,
      },
      autoFocus: false,
      maxWidth: '120vh',
    });
    dialogRef.afterClosed().subscribe((response: any) => {
      if (response.accept && response.indications) {
        d.indications = response.indications;
        d.$id = Date.now();
        const index = this.note.treatments.list.indexOf(d);
        if (index === -1) {
          this.note.treatments.list.push(d);
        }
      } else {
        d.indications = '';
      }

      this.treatmentList = [];
      //console.log("Dialog output:", response)
    });

    this.selectedTreatment = undefined;
    this.searchTreatment = '';
  }

  removeTreatment(d) {
    if (!this.isEditable) {
      return;
    }
    let index = this.note.treatments.list.indexOf(d);
    if (index !== -1) {
      this.note.treatments.list.splice(index, 1);
    }
  }

  getInterconsultations(termEntered: string) {
    let str = termEntered;
    // this.interconsultationCtrl.valueChanges.subscribe((value: string) => {
    //   str += value;
    // });
    clearTimeout(this.tempTimeobj);
    this.tempTimeobj = setTimeout(() => {
      if (str.length >= 2) {
        this.showInterconsultantionProgressBar = true;
        this.noteService.queryInterconsultations(str).then((response: any) => {
          this.showInterconsultantionProgressBar = false;
          this.interconsultationList = response;
        });
      }
    }, 1000);
  }

  addSpecialty(d) {
    if (!d || !this.isEditable) {
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
    if (!this.isEditable) {
      return;
    }
    var index = this.note.referrals.list.indexOf(d);
    if (index !== -1) {
      this.note.referrals.list.splice(index, 1);
    }
  }
}
