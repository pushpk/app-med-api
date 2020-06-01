import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';
import { NoteService } from '../../services/note.service';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { map, startWith } from 'rxjs/operators';
import { MatAutocomplete, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';

@Component({
  selector: 'app-form-conclusion',
  templateUrl: './form-conclusion.component.html',
  styleUrls: ['./form-conclusion.component.scss']
})
export class FormConclusionComponent implements OnInit {
  diagnosisCtrl = new FormControl();
  options: string[] = ['One', 'Two', 'Three'];
  filteredDiagnosis: Observable<string[]>;
  selectedDiagnosis: any[] = [];
  resources: any;
  @Input() note: any;

  constructor(public noteService: NoteService) { }

  ngOnInit(): void {
    this.noteService.resources.subscribe((o) => {
      this.resources = o;
      this.filteredDiagnosis = this.diagnosisCtrl.valueChanges.pipe(
        startWith(null),
        map((data: string | null) => data ? this._filter(data) : this.resources.cardiovascularSymptom.slice()));
    });
    console.log(this.note, 'note');
  }

  private _filter(value: any): string[] {
    const filterValue = value.name.toLowerCase();
    return this.resources.cardiovascularSymptom.filter(x => x.name.toLowerCase().indexOf(filterValue) === 0);
  }
  selected(event: MatAutocompleteSelectedEvent) {

  }
}
