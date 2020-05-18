import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit {
  patient: any;
  note: any;
  resources: any;

  selectedDiagnosis: any;
  searchDiagnosis: string;

  selectedExam: any;
  searchExam: string;

  selectedTreatment: any;
  searchTreatment: string;

  selectedSpecialty: any;
  searchSpecialty: string;

  submit = {
    waiting: false,
    success: false
  };

  tabs: Array<{ title: string; template: string }>;

  constructor() {
    const self = this;
    self.resources = null;
    self.selectedDiagnosis = null;
    self.searchDiagnosis = '';

    self.selectedTreatment = null;
    self.searchTreatment = '';

    self.selectedExam = null;
    self.searchExam = '';

    self.selectedSpecialty = null;
    self.searchSpecialty = '';

  }

  ngOnInit(): void {
  }

}
