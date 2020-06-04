import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';
import { NoteService } from '../../services/note.service';
import { MatChipInputEvent } from '@angular/material/chips';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { MatAutocomplete, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { map, startWith } from 'rxjs/operators';

@Component({
  selector: 'app-cardio-form-symptoms',
  templateUrl: './cardio-form-symptoms.component.html',
  styleUrls: ['./cardio-form-symptoms.component.scss']
})
export class CardioFormSymptomsComponent implements OnInit {
  resources: any;
  @Input() note: any;
  @Input() patient: any;
  public visible = true;
  public selectable = true;
  public removable = true;
  public addOnBlur = true;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  symptomsCtrl = new FormControl();
  filteredSymptoms: Observable<string[]>;
  selectedSymptoms: any[] = [];
  @ViewChild('symptomInput') symptomInput: ElementRef<HTMLInputElement>;
  @ViewChild('auto') matAutocomplete: MatAutocomplete;

  constructor(public noteService: NoteService) {
  }

  ngOnInit(): void {
    this.noteService.resources.subscribe((o) => {
      this.resources = o;
      console.log(this.resources, '  this.resources');
      this.filteredSymptoms = this.symptomsCtrl.valueChanges.pipe(
        startWith(null),
        map((data: string | null) => data ? this._filter(data) : this.resources.cardiovascularSymptom.slice()));
    });
  }
  add(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    if ((value || '').trim()) {
      this.selectedSymptoms.push(event);
    }

    if (input) {
      input.value = '';
    }

    this.symptomsCtrl.setValue(null);
  }

  remove(o: string): void {
    const index = this.selectedSymptoms.indexOf(o);

    if (index >= 0) {
      this.selectedSymptoms.splice(index, 1);
    }
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    if (this.selectedSymptoms.indexOf(event.option.value) === -1) {
      this.selectedSymptoms.push(event.option.value);
    }
    this.symptomInput.nativeElement.value = '';
    this.symptomsCtrl.setValue(null);
  }

  private _filter(value: any): string[] {
    const filterValue = value.name.toLowerCase();
    return this.resources.cardiovascularSymptom.filter(x => x.name.toLowerCase().indexOf(filterValue) === 0);
  }

  addSymptoms(data) {
    if (this.selectedSymptoms.indexOf(data) === -1) {
      this.selectedSymptoms.push(data);
    }
  }
}
